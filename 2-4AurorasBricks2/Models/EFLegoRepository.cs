namespace _2_4AurorasBricks2.Models
{
    public class EFLegoRepository: ILegoRepository
    {
        private LegoContext _context;
        public EFLegoRepository(LegoContext temp)
        {
            _context = temp;
        }

        public IQueryable<Customer> Customers => _context.Customers;
        public IQueryable<Order> Orders => _context.Orders;
        public IQueryable<LineItem> LineItems => _context.LineItems;
        public IQueryable<Product> Products => _context.Products;
    }
}
