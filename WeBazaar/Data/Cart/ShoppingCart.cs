using Microsoft.EntityFrameworkCore;
using WeBazaar.Models;

namespace WeBazaar.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(Item item)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Item.Id == item.Id &&
                n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {

                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Item = item,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId ==
            ShoppingCartId).Include(n => n.Item).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId ==
            ShoppingCartId).Select(n => n.Item.Price * n.Amount).Sum();


    }
}
