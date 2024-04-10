namespace _2_4AurorasBricks2.Models.ViewModels
{
    public class ProjectsListViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    }
}
