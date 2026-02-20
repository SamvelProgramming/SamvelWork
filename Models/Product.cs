using System.ComponentModel.DataAnnotations.Schema;
namespace AramatBags.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        //public string Currency { get; set; }
        [ForeignKey("CategoryId")]
        public int? ProductCategoryId { get; set; }
        public int Price { get; set; }
        //public List<string> Reviews { get; set; }
        public int ProductCount { get; set; }
        public string Image { get; set; }
        public Category category { get; set; }
    }
}

