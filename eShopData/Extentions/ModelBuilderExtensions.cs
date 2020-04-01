using eShopData.Entities;
using eShopData.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopData.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key ="HomeTitle",Value="This is home page of eShop"},
                new AppConfig() { Key ="HomeKeyWord", Value ="This is keyword of eShop" },
                new AppConfig() { Key ="HomeDescription",Value ="This is description of eShop"}
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = " Englist", IsDefault = false }
                );

            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   Id = 1,
                   IsShowOnHome = true,
                   ParentId = null,
                   SortOrder = 1,
                   Status = Status.Active,
               },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active
                });

            modelBuilder.Entity<CategoryTranslatation>().HasData(
                 new CategoryTranslatation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                 new CategoryTranslatation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                 new CategoryTranslatation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                 new CategoryTranslatation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                  );

            modelBuilder.Entity<Product>().HasData(
              new Product()
              {
                  Id = 1,
                  DateCreated = DateTime.Now,
                  OriginalPrice = 100000,
                  Price = 200000,
                  Stock = 0,
                  ViewCount = 0,
              });

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Áo sơ mi nam trắng Việt Tiến",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                    SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                    SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                    Details = "Áo sơ mi nam trắng Việt Tiến",
                    Description = "Áo sơ mi nam trắng Việt Tiến"
                },
                   new ProductTranslation()
                   {
                       Id = 2,
                       ProductId = 1,
                       Name = "Viet Tien Men T-Shirt",
                       LanguageId = "en-US",
                       SeoAlias = "viet-tien-men-t-shirt",
                       SeoDescription = "Viet Tien Men T-Shirt",
                       SeoTitle = "Viet Tien Men T-Shirt",
                       Details = "Viet Tien Men T-Shirt",
                       Description = "Viet Tien Men T-Shirt"
                   });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // any guid
            var roleId = Guid.NewGuid();
            var adminId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "dan@gmail.com",
                NormalizedEmail = "dandan@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "12345"),
                SecurityStamp = string.Empty,
                FirstName = "Dan",
                LastName = "Dan",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

        }
    }
}
