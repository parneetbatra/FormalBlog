using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using FormalBlog.Core.Attributes;

namespace FormalBlog.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("GetAll/{PageNo}/{PageSize}/{Search}")]
        public Infrastructure.ViewModels.Response GetAll(int PageNo, int PageSize, string Search)
        {
            return Core.Services.User.GetAll(PageNo, PageSize, Search);
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAjax]
        [HttpPost]
        [Route("Login")]
        public Infrastructure.ViewModels.Response Login([FromForm] Infrastructure.ViewModels.User.Login model)
        {
            return Core.Services.User.Authenticate(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Signup")]
        public Infrastructure.ViewModels.Response Create(Infrastructure.ViewModels.User.Signup model)
        {
            model.LastLoginIP = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();

            return Core.Services.User.Create(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ResentEmail")]
        public Infrastructure.ViewModels.Response ResentEmail(string Email)
        {
            return Core.Services.User.ResentEmail(Email);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ForgetPassword")]
        public Infrastructure.ViewModels.Response ForgetPassword(string Email)
        {
            return Core.Services.User.ForgetPassword(Email);
        }

        [HttpGet("User/{id}")]
        public Infrastructure.ViewModels.Response GetById(int id)
        {
            return Core.Services.User.GetById(id);
        }

        [HttpPost]
        [Route("GetByEmail")]
        public Infrastructure.ViewModels.Response GetByEmail(string email)
        {
            return Core.Services.User.GetByEmail(email);
        }

        [HttpPut]
        [Route("")]
        public Infrastructure.ViewModels.Response Update(Infrastructure.Models.User model)
        {
            return Core.Services.User.Update(model);
        }


        [HttpPost]
        [Route("NewPassword")]
        public Infrastructure.ViewModels.Response NewPassword(string GUID, DateTime ResetPasswordCodeDate, string NewPassword)
        {
            return Core.Services.User.NewPassword(GUID, ResetPasswordCodeDate, NewPassword);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public Infrastructure.ViewModels.Response ChangePassword(string Email, string OldPassword, string NewPassword)
        {
            return Core.Services.User.ChangePassword(Email, OldPassword, NewPassword);
        }

        [HttpDelete]
        [Route("")]
        public Infrastructure.ViewModels.Response Delete(Infrastructure.Models.User model)
        {
            return Core.Services.User.Update(model);
        }

    }
}
