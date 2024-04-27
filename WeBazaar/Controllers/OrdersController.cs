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
        public IActionResult Index()
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
    }
}
