namespace api.multitracks.com
{
    public class PaginationResults
    {
        public int CurrentPageNum { get; set; }
        public int PageSize { get; set; }
        public List<Song> Songs { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
    }
}
