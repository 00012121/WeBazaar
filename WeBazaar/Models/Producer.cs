using System.ComponentModel.DataAnnotations;

namespace WeBazaar.Models
{
    public class Producer
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
