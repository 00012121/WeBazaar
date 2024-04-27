using Microsoft.EntityFrameworkCore;
using WeBazaar.Data.Base;
using WeBazaar.Data.ViewModels;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public class ItemsService : EntityBaseRepository<Item>, IItemsService
    {
        private readonly AppDbContext _context;
        public ItemsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewItemAsync(NewItemVM data)
        {
            var newItem = new Item()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CompanyId = data.CompanyId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ItemCategory = data.ItemCategory,
                ProducerId = data.ProducerId,
            };
            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();

            //Add item similar products
            foreach (var productId in data.ProductIds)
            {
                var newProductItem = new Product_Item()
                {
                    ItemId = newItem.Id,
                    ProductId = productId,
                };
                await _context.Products_Items.AddAsync(newProductItem);
            }
            await _context.SaveChangesAsync();
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

        public async Task<NewItemDropdownsVM> GetNewItemDropdownsValues()
        {
            var response = new NewItemDropdownsVM()
            {
                Products = await _context.Products.OrderBy(n => n.FullName).ToListAsync(),
                Companies = await _context.Companies.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateItemAsync(NewItemVM data)
        {
            var dbItem = await _context.Items.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbItem != null)
            {
                dbItem.Name = data.Name;
                dbItem.Description = data.Description;
                dbItem.Price = data.Price;
                dbItem.ImageURL = data.ImageURL;
                dbItem.CompanyId = data.CompanyId;
                dbItem.StartDate = data.StartDate;
                dbItem.EndDate = data.EndDate;
                dbItem.ItemCategory = data.ItemCategory;
                dbItem.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();

            }

            //Remove existing products
            var existingProductsDb = _context.Products_Items.Where(n => n.ItemId == data.Id).ToList();  
            _context.Products_Items.RemoveRange(existingProductsDb);
            await _context.SaveChangesAsync();

            //Add item similar products
            foreach (var productId in data.ProductIds)
            {
                var newProductItem = new Product_Item()
                {
                    ItemId = data.Id,
                    ProductId = productId,
                };
                await _context.Products_Items.AddAsync(newProductItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
