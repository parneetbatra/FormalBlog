using System.Collections.Generic;

namespace FormalBlog.Infrastructure.ViewModels.User
{
    public class Table
    {
        public List<Models.User> Users { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
