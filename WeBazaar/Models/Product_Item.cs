namespace WeBazaar.Models
{
    public class Product_Item
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
