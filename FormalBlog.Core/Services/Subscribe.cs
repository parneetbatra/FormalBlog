using FormalBlog.Infrastructure.EntityFramework;
using FormalBlog.Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FormalBlog.Core.Services
{
    public static class Subscribe
    {
        public static Response GetAll(int PageNo, int PageSize, string Search)
        {
            Response Response = new Response();
            Infrastructure.ViewModels.Subscribe.Paging Subscribe = new Infrastructure.ViewModels.Subscribe.Paging();
            try
            {
                using (var db = Helper.db)
                {
                    if (String.IsNullOrEmpty(Search))
                    {
                        int TotalRecords = db.Subscribers.ToList().Count();
                        int Skip = PageSize * (PageNo - 1);

                        Subscribe.PageNo = PageNo;
                        Subscribe.PageSize = PageSize;
                        Subscribe.TotalRecords = TotalRecords;

                        Subscribe.Subscribers = db.Subscribers.OrderBy(x => x.Id).Skip(Skip).Take(PageSize).ToList();
                    }
                    else
                    {
                        int Skip = PageSize * (PageNo - 1);

                        Subscribe.Subscribers = db.Subscribers
                            .Where(x => x.Email.Contains(Search))
                            .OrderBy(x => x.Id)
                            .Skip(Skip).Take(PageSize).ToList();

                        int TotalRecords = Subscribe.Subscribers.Count();

                        Subscribe.PageNo = PageNo;
                        Subscribe.PageSize = PageSize;
                        Subscribe.TotalRecords = TotalRecords;
                    }
                }

                Response.Status = "Success";
                Response.Output = Subscribe;
                return Response;
            }
            catch (Exception ex)
            {
                Helper.Error(ex);

                Response.Status = "Error";
                return Response;
            }
            finally
            {
                Subscribe = null;
            }
        }

        public static Response Create(Infrastructure.Models.Subscribe Model)
        {
            Response Response = new Response();
            Infrastructure.Models.Subscribe Subscribe = new Infrastructure.Models.Subscribe();

            Guid GUID = Guid.NewGuid();

            try
            {
                if (Model != null)
                {
                    using (var db = Helper.db)
                    {
                        Subscribe = db.Subscribers.Where(x => x.Email == Model.Email).FirstOrDefault();
                        if (Subscribe == null)
                        {
                            Subscribe.Datetime = DateTime.UtcNow;
                            Subscribe.Verified = false;
                            Subscribe.Subscribed = true;
                            Subscribe.VerificationCode = GUID.ToString();

                            db.Subscribers.Add(Model);
                            db.SaveChanges();

                            Response.Status = "Success";
                            Response.Message = "Successfully Subscribed. We sent a confirmation email, please verify.";
                        }
                        else
                        {
                            db.Entry(Subscribe).State = EntityState.Detached;

                            Subscribe.Subscribed = true;

                            db.Subscribers.Update(Subscribe);
                            db.SaveChanges();

                            Response.Status = "Success";
                            if (Subscribe.Verified == true)
                            {
                                Response.Message = "Successfully Subscribed.";
                            }
                            else
                            {
                                Response.Message = "Successfully Subscribed. We sent a confirmation email, please verify.";
                            }
                        }
                    }

                    return Response;
                }
                else
                {
                    Response.Status = "Error";
                    Response.Message = "Something went wrong, please try after sometime.";
                    Response.Output = null;

                    return Response;
                }
            }
            catch (Exception ex)
            {
                Core.Helper.Error(ex);

                Response.Status = "Error";
                Response.Message = ex.Message;
                return Response;
            }
            finally
            {
                Subscribe = null;
                Response = null;
            }
        }

        public static Response Update(Infrastructure.Models.Subscribe Model)
        {
            Response Response = new Response();
            Infrastructure.Models.Subscribe Subscribe = new Infrastructure.Models.Subscribe();

            try
            {
                using (var db = Helper.db)
                {
                    Subscribe = db.Subscribers.Where(x => x.Id == Model.Id).FirstOrDefault();
                    if (Subscribe != null)
                    {
                        db.Subscribers.Update(Subscribe);
                        db.SaveChanges();

                        Response.Status = "Success";
                        Response.Message = "Successfully updated.";
                        Response.Output = Subscribe;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Can't find Subscribe.";
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
                Subscribe = null;
                Response = null;
            }
        }

        public static Response GetById(int Id)
        {
            Response Response = new Response();
            Infrastructure.Models.Subscribe Subscribe = new Infrastructure.Models.Subscribe();
            try
            {
                using (var db = Helper.db)
                {
                    Subscribe = db.Subscribers.Where(x => x.Id == Id).FirstOrDefault();
                    if (Subscribe != null)
                    {
                        Response.Status = "Success";
                        Response.Output = Subscribe;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "Can't find Subscribe.";

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
                Subscribe = null;
                Response = null;
            }
        }

        public static Response GetByEmail(string Email)
        {
            Response Response = new Response();
            Infrastructure.Models.Subscribe Subscribe = new Infrastructure.Models.Subscribe();
            try
            {
                using (var db = Helper.db)
                {
                    Subscribe = db.Subscribers.Where(x => x.Email == Email).FirstOrDefault();
                    if (Subscribe != null)
                    {
                        Response.Status = "Success";
                        Response.Output = Subscribe;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "Can't find Subscribe.";

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
                Subscribe = null;
                Response = null;
            }
        }

        public static Response Unsubscribed(string Email, string Id)
        {
            Response Response = new Response();
            Infrastructure.Models.Subscribe Subscribe = new Infrastructure.Models.Subscribe();
            try
            {
                Email = Core.Encryption.Decrypt(Email);
                Id = Core.Encryption.Decrypt(Id);

                using (var db = Helper.db)
                {
                    Subscribe = db.Subscribers.Where(x => x.Id == Convert.ToInt32(Id) && x.Email == Email).FirstOrDefault();
                    if (Subscribe != null)
                    {
                        db.Subscribers.Update(Subscribe);
                        db.SaveChanges();

                        Response.Status = "Success";
                        Response.Message = "Unsubscribed successfully.";
                        Response.Output = Subscribe;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Can't find subscription.";
                        return Response;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.Error(ex);

                Response.Status = "Error";
                Response.Message = ex.Message;
                return Response;
            }
            finally
            {
                Response = null;
                Subscribe = null;
            }
        }
    }
}
