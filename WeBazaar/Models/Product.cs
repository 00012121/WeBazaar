using System.ComponentModel.DataAnnotations;

namespace WeBazaar.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Relationship
        public List<Product_Item> Products_Items{ get; set; }
    }
}
