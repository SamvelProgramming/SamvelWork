namespace AramatBags.Models
{
    public class Payment
    {
        public int CardHolderName { get; set; }
        public int CardNumber { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public int CVV { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int ZipCode { get; set; }
    }
}
