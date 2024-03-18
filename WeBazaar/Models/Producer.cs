using System.ComponentModel.DataAnnotations;
using WeBazaar.Data.Base;

namespace WeBazaar.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="Profile picture")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationship
        public List<Item> Items { get; set; }
    }
}
