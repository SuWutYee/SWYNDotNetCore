namespace DotNetCoreTraining.MvcApp.Models
{
    public class BlogResponseModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public bool IsEndPage => PageNo >= PageCount;
        public List<BlogModel> Blogs { get; set; }
    }
}
