using Microsoft.AspNetCore.Mvc;
using WeBazaar.Data.Cart;
using WeBazaar.Data.Services;
using WeBazaar.Data.ViewModels;

namespace WeBazaar.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IItemsService _itemsService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IItemsService itemsService, ShoppingCart shoppingCart)
        {
            _itemsService = itemsService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _itemsService.GetItemByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _itemsService.GetItemByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
