using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> FindAllProducts(string token);
        Task<ProductViewModel> GetProductById(long id, string token);
        Task<ProductViewModel> CreateProduct(ProductViewModel product, string token);
        Task<ProductViewModel> UpdateProduct(ProductViewModel product, string token);
        Task<bool> DeleteProductById(long id, string token);
    }
}
