using WeBazaar.Models;

namespace WeBazaar.Data.ViewModels
{
    public class NewItemDropdownsVM
    {
        public NewItemDropdownsVM()
        {
            Producers = new List<Producer>();
            Companies = new List<Company>();
            Products = new List<Product>();
        }
        public List<Producer> Producers { get; set; }
        public List<Company> Companies { get; set; }
        public List<Product>  Products { get; set; }
    }
}
