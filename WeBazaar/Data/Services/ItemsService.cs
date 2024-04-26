using Microsoft.EntityFrameworkCore;
using WeBazaar.Data.Base;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public class ItemsService:EntityBaseRepository<Item>, IItemsService
    {
        private readonly AppDbContext _context;
        public ItemsService(AppDbContext context):base (context) 
        { 
            _context = context;
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            var itemDetails = await _context.Items
                .Include(c => c.Company)
                .Include(c => c.Producer)
                .Include(am => am.Products_Items).ThenInclude(a => a.Product)
                .FirstOrDefaultAsync(n => n.Id == id);

            return itemDetails;
        }
    }
}
