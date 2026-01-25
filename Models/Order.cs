namespace AramatBags.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int CardHolderName { get; set; }
        public int CardNumber { get; set; } 
        public int CVV { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int ZipCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
    }
}
