using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WeBazaar.Data.Base;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context) { }
    }
}
