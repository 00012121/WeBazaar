using System.ComponentModel.DataAnnotations;

namespace WeBazaar.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationship
        public List<Item> Items { get; set; }
    }
}
