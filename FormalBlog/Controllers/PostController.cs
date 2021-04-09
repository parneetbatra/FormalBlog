using FormalBlog.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormalBlog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        [HttpGet]
        [Route("{URL}")]
        public IActionResult Index(string URL)
        {            
            return View(Core.Services.Post.GetByURL(URL));
        }

        [HttpGet]
        [Route("Post/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Post/Create")]
        public Response Create(Infrastructure.Models.Post Model)
        {
            return Core.Services.Post.Create(Model);
        }

        [HttpGet]
        [Route("Post/{Id}")]
        public IActionResult Update(int Id)
        {
            return View();
        }

        [HttpPut]
        [Route("Post/Update")]
        public Response Update(Infrastructure.Models.Post Model)
        {
            return Core.Services.Post.Update(Model);
        }

        [HttpDelete]
        [Route("Post/Delete")]
        public Response Delete(int Id)
        {
            return Core.Services.Post.Delete(Id);
        }
    }
}
