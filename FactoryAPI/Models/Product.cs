namespace FactoryAPI
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public double Stock { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
