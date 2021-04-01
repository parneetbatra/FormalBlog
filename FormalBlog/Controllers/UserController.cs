using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FormalBlog.Infrastructure.EntityFramework;
using System;
using FormalBlog.Core.Attributes;

namespace FormalBlog.Controllers
{
    public class UserController : Controller
    {
        private DatabaseContext db;
        public UserController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("GetAll/{PageNo}/{PageSize}/{Search}")]
        public Infrastructure.ViewModels.Response GetAll(int PageNo, int PageSize, string Search)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.GetAll(PageNo, PageSize, Search);
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
            Core.Services.User UserService = new Core.Services.User(db);
            Infrastructure.ViewModels.Response Response = new Infrastructure.ViewModels.Response();

            try
            {
                return UserService.Authenticate(model);
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);
            }
            return Response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Signup")]
        public Infrastructure.ViewModels.Response Create(Infrastructure.ViewModels.User.Signup model)
        {
            model.LastLoginIP = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Core.Services.User User = new Core.Services.User(db);

            return User.Create(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ResentEmail")]
        public Infrastructure.ViewModels.Response ResentEmail(string Email)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.ResentEmail(Email);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ForgetPassword")]
        public Infrastructure.ViewModels.Response ForgetPassword(string Email)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.ForgetPassword(Email);
        }

        [HttpGet("{id}")]
        public Infrastructure.ViewModels.Response GetById(int id)
        {
            Core.Services.User User = new Core.Services.User(db);
            try
            {
                return User.GetById(id);
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);
                return null;
            }
            finally
            {
                User = null;
            }
        }

        [HttpPost]
        [Route("GetByEmail")]
        public Infrastructure.ViewModels.Response GetByEmail(string email)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.GetByEmail(email);
        }

        [HttpPut]
        [Route("")]
        public Infrastructure.ViewModels.Response Update(Infrastructure.Models.User model)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.Update(model);
        }


        [HttpPost]
        [Route("NewPassword")]
        public Infrastructure.ViewModels.Response NewPassword(string GUID, DateTime ResetPasswordCodeDate, string NewPassword)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.NewPassword(GUID, ResetPasswordCodeDate, NewPassword);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public Infrastructure.ViewModels.Response ChangePassword(string Email, string OldPassword, string NewPassword)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.ChangePassword(Email, OldPassword, NewPassword);
        }

        [HttpDelete]
        [Route("")]
        public Infrastructure.ViewModels.Response Delete(Infrastructure.Models.User model)
        {
            Core.Services.User User = new Core.Services.User(db);

            return User.Update(model);
        }

    }
}
