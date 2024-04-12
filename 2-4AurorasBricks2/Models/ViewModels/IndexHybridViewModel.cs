namespace _2_4AurorasBricks2.Models.ViewModels
{
    public class IndexHybridViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public Dictionary<string, List<Product>>? RecommendedProducts { get; set; }
        public List<int> PreLoadedRecommendations { get; set; }

    }
}
