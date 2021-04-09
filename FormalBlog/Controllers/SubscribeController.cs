using FormalBlog.Core.Attributes;
using FormalBlog.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormalBlog.Controllers
{
    public class SubscribeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAjax]
        [Route("Subscribe/Create")]
        [HttpPost]
        public Response Create(Infrastructure.Models.Subscribe Model)
        {
            return Core.Services.Subscribe.Create(Model);
        }
    }
}
