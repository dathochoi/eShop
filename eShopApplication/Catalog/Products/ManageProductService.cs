using eShopApplication.Common;
using eShopData.EF;
using eShopData.Entities;
using eshopUtilities.Exceptions;
using eShopViewModel.Catalog.ProductImages;
using eShopViewModel.Catalog.Products;
using eShopViewModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace eShopApplication.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> AddImages(int ProductId, ProductImageCreateRequest  request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreate = DateTime.Now,
                IsDefaul = request.isDefault,
                ProductId = ProductId,
                SortOrder = request.SortOrder
            };
            if(request.ImageFilfe != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFilfe);
                productImage.FileSize = request.ImageFilfe.Length;
            }
            _context.ProducImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;

        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrince,
                Stock = request.Stock,
                ViewCount = request.Stock,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId= request.LanguageId
                    }
                }
            };

            if(request.TumbnailImage !=null)
            {
                product.ProducImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreate = DateTime.Now,
                        FileSize = request.TumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.TumbnailImage),
                        IsDefaul =true,
                        SortOrder =1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }
        

        private async Task<string> SaveFile(IFormFile tumbnailImage)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(tumbnailImage.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(tumbnailImage.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<int> Delete(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null) throw new EShopException($"Cannot find a product: {ProductId}");
           
            var images = _context.ProducImages.Where(x => x.ProductId == ProductId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsynce(image.ImagePath);
            }
            return await _context.SaveChangesAsync(); 
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            if (request.CategoryIds.Count > 0)
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock =x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();


            var pageedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageedResult;
        }

        public async Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            return await _context.ProducImages.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreate = i.DateCreate,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefaul,
                    ProductId =i.ProductId,
                    SortOrder = i.SortOrder         
                }).ToListAsync();
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.ProducImages.FindAsync(imageId);
            if (productImage == null)
                throw new EShopException($"Cannot find an iamge with id{imageId}");
            _context.ProducImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId);

            if (product == null || productTranslations == null) throw new EShopException($"Cannot find a product with id: {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;

            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProducImages.FirstOrDefaultAsync(i => i.IsDefaul == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProducImages.Update(thumbnailImage);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProducImages.FindAsync(imageId);
            if (productImage == null)
                throw new EShopException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProducImages.Update(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int ProductId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null) throw new EShopException($"Cannot find a product with id: {ProductId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int ProductId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null) throw new EShopException($"Cannot find a product with id: {ProductId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ProductViewModel> GetById(int productId, string languageId)
        {
            var product = await _context.Products.FindAsync(productId);
            var productTrannslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == languageId);

            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTrannslation != null ? productTrannslation.Description : null,
                LanguageId = productTrannslation.LanguageId,
                Details = productTrannslation != null ? productTrannslation.Details : null,
                Name = productTrannslation != null ? productTrannslation.Name : null,
                OginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTrannslation != null ? productTrannslation.SeoAlias : null,
                SeoDescription = productTrannslation != null ? productTrannslation.SeoDescription : null,
                SeoTitle = productTrannslation != null ? productTrannslation.SeoTitle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount


            };
            return productViewModel;
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProducImages.FindAsync(imageId);
            if (image == null)
                throw new EShopException($"Cannot find an image with id {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreate = image.DateCreate,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefaul,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }
    }
}
