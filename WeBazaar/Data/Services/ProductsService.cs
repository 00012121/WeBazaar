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
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);  
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Product> UpdateAsync(int id, Product newProduct)
        {
            _context.Update(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }
    }
}
