using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll();
        Product GetById(int id);
        void Add(Product product);
        Product Update(int id, Product newProduct);
        void Delete(int id);
    }
}
