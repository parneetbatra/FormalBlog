using System;
using System.Collections.Generic;
using System.Text;

namespace FormalBlog.Infrastructure.ViewModels
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Output { get; set; }
    }
}
