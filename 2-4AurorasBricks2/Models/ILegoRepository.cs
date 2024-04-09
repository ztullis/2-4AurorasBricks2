namespace _2_4AurorasBricks2.Models
{
    public interface ILegoRepository
    {
        public IQueryable<Order> Orders { get; }
        public IQueryable<LineItem> LineItems { get; }
        public IQueryable<Product> Products { get; }
        public IQueryable<Customer> Customers { get; }
    }
}
