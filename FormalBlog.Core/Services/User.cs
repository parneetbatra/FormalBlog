using Microsoft.IdentityModel.Tokens;
using FormalBlog.Infrastructure.EntityFramework;
using FormalBlog.Infrastructure.ViewModels;
using FormalBlog.Infrastructure.ViewModels.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FormalBlog.Core.Services
{
    public static class User
    {
        public static Response Authenticate(Login Login)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();

            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Email == Login.Email && x.Password == Core.Encryption.Encrypt(Login.Password) && x.Active == true && x.EmailVerified == true).FirstOrDefault();

                    // return null if user not found
                    if (User == null)
                    {
                        User = new Infrastructure.Models.User();
                        User = db.Users.Where(x => x.Email == Login.Email && x.Password == Core.Encryption.Encrypt(Login.Password)).FirstOrDefault();
                        if (User != null)
                        {
                            if (User.EmailVerified == false)
                            {
                                Response.Status = "Warning";
                                Response.Message = "Your email is not verified yet. Please check your email and verify. If you haven't got any email, click on resent the email.";
                                Response.Output = null;

                                return Response;
                            }

                            if (User.Active == false)
                            {
                                Response.Status = "Error";
                                Response.Message = "Your account is inactive, please contact to support team for more information.";
                                Response.Output = null;

                                return Response;
                            }

                        }

                        Response.Status = "Error";
                        Response.Message = "Invalid email or/and password.";
                        Response.Output = User;

                        return Response;
                    }

                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(Core.Helper.AppSettings.AuthenticationSecretKey);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, User.Id.ToString()),
                        new Claim(ClaimTypes.Role, User.Role)
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    User.Token = tokenHandler.WriteToken(token);

                    Response.Status = "Success";
                    Response.Message = "Login successfull";
                    Response.Output = User;

                    return Response;
                }
            }
            catch (Exception ex)
            {
                Helper.Error(ex);

                Response.Status = "Error";
                Response.Message = "Something went wrong, please try after sometime.";

                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response GetAll(int PageNo, int PageSize, string Search)
        {
            Response Response = new Response();
            List<Infrastructure.Models.User> Users = new List<Infrastructure.Models.User>();
            Infrastructure.ViewModels.User.Table Table = new Infrastructure.ViewModels.User.Table();

            try
            {
                using (var db = Helper.db)
                {
                    int TotalRecords = db.Users.ToList().Count();

                    if (string.IsNullOrEmpty(Search))
                    {
                        Table.Users = db.Users.Where(x => x.Email.Contains(Search) || x.FirstName.Contains(Search) || x.LastName.Contains(Search)).ToList();
                    }
                    else
                    {
                        Table.Users = db.Users.ToList();
                    }

                    int Total = Table.Users.Count();
                    int Skip = PageSize * (PageNo - 1);

                    Table.PageNo = PageNo;
                    Table.PageSize = PageSize;
                    Table.TotalRecords = TotalRecords;
                    Table.Users = Table.Users.Skip(Skip).Take(PageSize).ToList();

                    if (Table != null)
                    {
                        Response.Status = "Success";
                        Response.Output = Table;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Can't find user.";
                        Response.Output = Table;

                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                return Response;
            }
            finally
            {
                Response = null;
                Users = null;
                Table = null;
            }
        }

        public static Response Create(Infrastructure.ViewModels.User.Signup model)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();

            Guid GUID = Guid.NewGuid();

            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Email == model.Email).FirstOrDefault();

                    if (User == null)
                    {
                        User = new Infrastructure.Models.User();

                        User.FirstName = model.FirstName;
                        User.LastName = model.LastName;
                        User.Password = Core.Encryption.Encrypt(model.Password);
                        User.Email = model.Email;

                        User.EmailVerificationCodeDate = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                        User.EmailVerificationCode = GUID.ToString();
                        User.EmailVerified = false;
                        User.Role = "User";
                        User.CreatedDate = DateTime.UtcNow;
                        User.LastLoginDate = DateTime.UtcNow;
                        User.Active = true;

                        db.Users.Add(User);
                        db.SaveChanges();

                        // create fields before return
                        User.Password = "";

                        // login
                        // authentication successful so generate jwt token
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(Core.Helper.AppSettingsSecret);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                            new Claim(ClaimTypes.Name, User.Id.ToString()),
                            new Claim(ClaimTypes.Role, User.Role)
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        User.Token = tokenHandler.WriteToken(token);

                        Response.Status = "Success";
                        Response.Message = "Successfully created account. We have sent the confirmation email to " + model.Email + ". Please go to your email and verify.";
                        Response.Output = null;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "You have already registered with us. Please login to your account or forgot password.";
                        Response.Output = null;

                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                Response.Message = "";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response Update(Infrastructure.Models.User model)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();

            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (User != null)
                    {
                        User.FirstName = model.FirstName;
                        User.LastName = model.LastName;
                        User.Email = model.Email;

                        db.Users.Update(User);
                        db.SaveChanges();

                        Response.Status = "Success";
                        Response.Message = "Successfully updated.";
                        Response.Output = User;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Can't find user.";
                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                Response.Message = "";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response GetById(int Id)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();
            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Id == Id).FirstOrDefault();
                    if (User != null)
                    {
                        User.Password = "";

                        Response.Status = "Success";
                        Response.Output = User;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "Can't find user.";

                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response GetByEmail(string Email)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    using (var db = Helper.db)
                    {
                        User = db.Users.Where(x => x.Email == Email).FirstOrDefault();
                        if (User != null)
                        {
                            // clear password before return
                            User.Password = "";

                            Response.Status = "Success";
                            Response.Message = "Found.";
                            Response.Output = User;

                            return Response;
                        }
                    }
                }

                Response.Status = "Error";
                Response.Message = "Not found.";
                return Response;
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                Response.Message = "";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response Delete(int Id)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();

            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Id == Id).FirstOrDefault();
                    if (User != null)
                    {
                        //    User.Deleted = true;
                        //    User.DeletedDate = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

                        db.Users.Update(User);
                        db.SaveChanges();

                        Response.Status = "Success";
                        Response.Message = "Deleted successfully.";
                        Response.Output = User;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Can't find user.";
                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                Response.Message = "";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response ForgetPassword(string Email)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();
            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Email == Email).FirstOrDefault();
                    if (User != null)
                    {
                        // send email for forgot password

                        Response.Status = "Success";
                        Response.Message = "We have sent reset link in your email (" + Email + "). Please open that email and reset password.";
                        Response.Output = null;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Not found.";
                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response NewPassword(string GUID, DateTime ResetPasswordCodeDate, string NewPassword)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();
            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.ResetPasswordCode == GUID).FirstOrDefault();
                    if (User != null)
                    {
                        DateTime now = DateTime.UtcNow;
                        if (ResetPasswordCodeDate > now.AddHours(-24) && ResetPasswordCodeDate <= now)
                        {
                            User.Password = NewPassword;

                            db.Users.Update(User);
                            db.SaveChanges();

                            Response.Status = "Success";
                            Response.Message = "Successfully saved new password. Please try to login.";
                            Response.Output = User;

                            return Response;
                        }
                        else
                        {
                            Response.Status = "Error";
                            Response.Message = "The link has expired. Please go to forget password page and generate another link for reset password.";
                            return Response;
                        }
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Not found.";
                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response ChangePassword(string Email, string OldPassword, string NewPassword)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();
            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Email == Email && x.Password == OldPassword).FirstOrDefault();
                    if (User != null)
                    {
                        User.Password = NewPassword;

                        db.Users.Update(User);
                        db.SaveChanges();

                        User.Password = "";

                        Response.Status = "Success";
                        Response.Message = "Successfully saved new password.";
                        Response.Output = User;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Not found.";
                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }

        public static Response ResentEmail(string Email)
        {
            Response Response = new Response();
            Infrastructure.Models.User User = new Infrastructure.Models.User();
            try
            {
                using (var db = Helper.db)
                {
                    User = db.Users.Where(x => x.Email == Email && x.EmailVerified == false).FirstOrDefault();
                    if (User != null)
                    {
                        // send email code

                        Response.Status = "Success";
                        Response.Message = "We have sent a confirmation email. Please check your email and verify. If you don't get an email, please check the spam folder or contact to support team.";
                        Response.Output = null;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Your account is already verified. Enter your credentials to access your account. If you don't remember your password, click on forgot password.";
                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                return Response;
            }
            finally
            {
                User = null;
                Response = null;
            }
        }
    }
}