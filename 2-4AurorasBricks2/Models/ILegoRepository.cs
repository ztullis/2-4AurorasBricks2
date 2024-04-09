namespace _2_4AurorasBricks2.Models
{
    public interface ILegoRepository
    {
        public IQueryable<Order> Orders { get; }
        public IQueryable<LineItem> LineItem { get; }
        public IQueryable<Product> Product { get; }
        public IQueryable<Customer> Customer { get; }
    }
}
