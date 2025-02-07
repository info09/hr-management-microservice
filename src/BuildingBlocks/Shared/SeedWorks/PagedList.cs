namespace Shared.SeedWorks
{
    public class PagedList<T> : PaginationBase where T : class
    {
        public List<T> Items { get; set; }
    }
}
    