using FirstMvcApp.Models;

namespace FirstMvcApp.Services;

public class ProductService : IProductService
{
    private static readonly List<Product> _products = new List<Product>();

    static ProductService()
    {
        _products.Add(new Product { Id = 1, Name = "Keyboard", Price = 20 });
        _products.Add(new Product { Id = 2, Name = "Mouse", Price = 10 });
        _products.Add(new Product { Id = 3, Name = "Monitor", Price = 100 });
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void CreateProduct(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }

    public void UpdateProduct(int id, Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}
