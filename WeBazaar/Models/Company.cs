using System.ComponentModel.DataAnnotations;
using WeBazaar.Data.Base;

namespace WeBazaar.Models
{
    public class Company : IEntityBase
    {
        //[Key]
        public int Id { get; set; }

        [Display(Name= "Company logo")]
        [Required(ErrorMessage ="Company logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Company name")]
        [Required(ErrorMessage = "Company name is required")]
        public string Name { get; set; }

        [Display(Name= "Description")]
        [Required(ErrorMessage = "Company description is required")]
        public string Description { get; set; }

        //Relationship
        public List<Item> Items { get; set; }
    }
}
