using FirstMvcApp.Models;

namespace FirstMvcApp.Services;

public interface IProductsReadOnlyService
{
    List<Product> GetAllProducts();
    Product? GetProductById(int id);
}
