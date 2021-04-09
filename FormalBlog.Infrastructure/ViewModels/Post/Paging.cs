﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalBlog.Infrastructure.ViewModels.Post
{
    public class Paging
    {
        public List<Infrastructure.Models.Post> Posts { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
