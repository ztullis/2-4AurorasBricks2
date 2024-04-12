namespace _2_4AurorasBricks2.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
        public string? CurrentLegoCategory { get; set; }
        public string? CurrentLegoColor { get; set; }
        public int? CurrentPageSize { get; set; }
    }
}

