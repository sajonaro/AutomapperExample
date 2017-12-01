namespace Domain
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get;set;}
        public Order[] Orders { get; set; }
    }
}
