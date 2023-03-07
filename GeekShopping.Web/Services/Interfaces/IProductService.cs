﻿using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> GetProductById(long id);
        Task<ProductModel> CreateProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<bool> DeleteProductById(long id);
    }
}
