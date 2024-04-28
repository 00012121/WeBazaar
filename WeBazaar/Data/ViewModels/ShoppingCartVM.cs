using System.Globalization;
using WeBazaar.Data.Cart;

namespace WeBazaar.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
        public CultureInfo culture = new CultureInfo("fr-FR");
    }
}
