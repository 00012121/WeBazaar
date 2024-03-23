using System.ComponentModel.DataAnnotations;
using WeBazaar.Data.Base;

namespace WeBazaar.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="Profile picture")]
        [Required(ErrorMessage = "Profile picture URL is required")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength (50, MinimumLength = 3, ErrorMessage ="Full name must be between 3 and 50 characters")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationship
        public List<Item> Items { get; set; }
    }
}
