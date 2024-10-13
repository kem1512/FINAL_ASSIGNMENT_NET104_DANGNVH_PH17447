namespace MinkyShop.Models
{
    public class PaginationViewModel
    {
        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }

        public string PageName { get; set; } = default!;
    }
}
