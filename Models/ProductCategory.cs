using System.ComponentModel.DataAnnotations;

namespace AramatBags.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
        public string? Image { get; set; }
    }
}
