using System.ComponentModel.DataAnnotations;
using WeBazaar.Data.Base;

namespace WeBazaar.Models
{
    public class Company : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name= "Company logo")]
        public string Logo { get; set; }

        [Display(Name = "Company name")]
        public string Name { get; set; }

        [Display(Name= "Description")]
        public string Description { get; set; }

        //Relationship
        public List<Item> Items { get; set; }
    }
}
