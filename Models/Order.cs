namespace AramatBags.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
