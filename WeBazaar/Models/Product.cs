using System.ComponentModel.DataAnnotations;

namespace WeBazaar.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name="Product name")]
        [Required(ErrorMessage = "Name of the product is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Product name must be between 5 and 100 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationship
        public List<Product_Item> Products_Items{ get; set; }
    }
}
