using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeBazaar.Data.Base;
using WeBazaar.Data.Enums;

namespace WeBazaar.Models
{
    public class NewItemVM
    {
        public int Id { get; set; }

        [Display(Name = "Item name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Item description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description{ get; set; }

        [Display(Name = "Item price in Uzbek so'm")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Item poster URL")]
        [Required(ErrorMessage = "Poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Start date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Item category is required")]
        public ItemCategory ItemCategory { get; set; }

        //Relationship with product
        [Display(Name = "Select similar product(s)")]
        [Required(ErrorMessage = "Product(s) is required")]
        public List<int> ProductIds { get; set; }

        [Display(Name = "Select a company")]
        [Required(ErrorMessage = "Company is required")]
        public int CompanyId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Product producer is required")]
        public int ProducerId { get; set; }

    }
}
