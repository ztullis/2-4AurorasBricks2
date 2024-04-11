namespace _2_4AurorasBricks2.Models.ViewModels
{
    public class SingleProductViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public Dictionary<string, List<Product>>? RecommendedProducts { get; set; }
    }
}
