using FirstMvcApp.Models;

namespace FirstMvcApp.Services;
public interface IProductService : IProductsReadOnlyService
{
    void CreateProduct(Product product);
    void DeleteProduct(int id);
    void UpdateProduct(int id, Product product);
}