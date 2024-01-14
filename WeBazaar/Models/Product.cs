using System.ComponentModel.DataAnnotations;

namespace WeBazaar.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile picture URL")]
        public string ProfilePictureURL { get; set; }

        [Display(Name="Full name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationship
        public List<Product_Item> Products_Items{ get; set; }
    }
}
