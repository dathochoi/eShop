using eShopViewModel.Catalog.ProductImages;
using eShopViewModel.Catalog.Products;
using eShopViewModel.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopApplication.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int ProductId);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task<bool> UpdatePrice(int ProductId, decimal newPrice);
        Task<bool> UpdateStock(int ProductId, int addedQuantity);
        Task AddViewCount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImages(int ProductId, ProductImageCreateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
        Task<ProductImageViewModel> GetImageById(int imageId);

    }
}
