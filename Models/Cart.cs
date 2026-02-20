namespace AramatBags.Models
{
    public class Cart
    {     
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public List<Product> Product { get; set; }
        public List<CartItem> CartItems { get; set; }
    }

}
