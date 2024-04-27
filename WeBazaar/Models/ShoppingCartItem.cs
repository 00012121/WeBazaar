using System.ComponentModel.DataAnnotations;

namespace WeBazaar.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
