using Task2.Models;

namespace Task2.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(Product product);
        Product UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
    }
}
