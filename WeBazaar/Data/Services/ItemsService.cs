using WeBazaar.Data.Base;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public class ItemsService:EntityBaseRepository<Item>, IItemsService
    {
        public ItemsService(AppDbContext context):base (context) 
        { 
            
        }
    }
}
