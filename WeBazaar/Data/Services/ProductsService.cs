using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(int id, Product newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
