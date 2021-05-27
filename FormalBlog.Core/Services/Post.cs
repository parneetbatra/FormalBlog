using FormalBlog.Infrastructure.EntityFramework;
using FormalBlog.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormalBlog.Core.Services
{
    public static class Post
    {
        public static Response GetAll(int PageNo, int PageSize, string Search)
        {
            Response Response = new Response();
            Infrastructure.ViewModels.Post.Paging Post = new Infrastructure.ViewModels.Post.Paging();
            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    if (String.IsNullOrEmpty(Search))
                    {
                        int TotalRecords = db.Posts.ToList().Count();
                        int Skip = PageSize * (PageNo - 1);

                        Post.PageNo = PageNo;
                        Post.PageSize = PageSize;
                        Post.TotalRecords = TotalRecords;

                        Post.Posts = db.Posts.OrderBy(x => x.Id).Skip(Skip).Take(PageSize).ToList();
                    }
                    else
                    {
                        int Skip = PageSize * (PageNo - 1);

                        Post.Posts = db.Posts
                            .Where(x => x.Title.Contains(Search) || x.Description.Contains(Search))
                            .OrderBy(x => x.Id)
                            .Skip(Skip).Take(PageSize).ToList();

                        int TotalRecords = Post.Posts.Count();

                        Post.PageNo = PageNo;
                        Post.PageSize = PageSize;
                        Post.TotalRecords = TotalRecords;
                    }
                }

                Response.Status = "Success";
                Response.Output = Post;
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
                Post = null;
            }
        }

        public static Response Create(Infrastructure.Models.Post Model)
        {
            Response Response = new Response();

            Guid GUID = Guid.NewGuid();

            try
            {
                if (Model != null)
                {
                  using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                    {
                        db.Posts.Add(Model);
                        db.SaveChanges();
                    }

                    Response.Status = "Success";
                    Response.Message = "Successfully Saved.";
                    Response.Output = null;

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
                Model = null;
                Response = null;
            }
        }

        public static Response Update(Infrastructure.Models.Post Model)
        {
            Response Response = new Response();
            Infrastructure.Models.Post Post = new Infrastructure.Models.Post();

            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    Post = db.Posts.Where(x => x.Id == Model.Id).FirstOrDefault();
                    if (Post != null)
                    {
                        db.Posts.Update(Post);
                        db.SaveChanges();

                        Response.Status = "Success";
                        Response.Message = "Successfully updated.";
                        Response.Output = Post;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Error";
                        Response.Message = "Can't find Post.";
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
                Post = null;
                Response = null;
            }
        }

        public static Response GetById(int Id)
        {
            Response Response = new Response();
            Infrastructure.Models.Post Post = new Infrastructure.Models.Post();
            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    Post = db.Posts.Where(x => x.Id == Id).FirstOrDefault();
                    if (Post != null)
                    {
                        Response.Status = "Success";
                        Response.Output = Post;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "Can't find Post.";

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
                Post = null;
                Response = null;
            }
        }

        public static Response GetByAuthor(int UserId)
        {
            Response Response = new Response();
            Infrastructure.Models.Post Post = new Infrastructure.Models.Post();
            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    Post = db.Posts.Where(x => x.UserId == UserId).FirstOrDefault();
                    if (Post != null)
                    {
                        Response.Status = "Success";
                        Response.Output = Post;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "No record found.";

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
                Post = null;
                Response = null;
            }
        }

        public static Response GetByStatus(string Status)
        {
            Response Response = new Response();
            List<Infrastructure.Models.Post> Post = new List<Infrastructure.Models.Post>();
            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    Post = db.Posts.Where(x => x.Status == Status).ToList();
                    if (Post != null)
                    {
                        Response.Status = "Success";
                        Response.Output = Post;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "No record found.";

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
                Post = null;
                Response = null;
            }
        }

        public static Response GetByURL(string URL)
        {
            Response Response = new Response();
            Infrastructure.Models.Post Post = new Infrastructure.Models.Post();
            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    Post = db.Posts.Where(x => x.URL == URL).FirstOrDefault();
                    if (Post != null)
                    {
                        Response.Status = "Success";
                        Response.Output = Post;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "Can't find Post.";

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
                Post = null;
                Response = null;
            }
        }

        public static Response Search(string Keyword)
        {
            Response Response = new Response();
            List<Infrastructure.Models.Post> Posts = new List<Infrastructure.Models.Post>();
            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    Posts = db.Posts.Where(x => x.Title.Contains(Keyword) || x.Description.Contains(Keyword)).ToList();
                    if (Posts.Count() > 0)
                    {
                        Response.Status = "Success";
                        Response.Output = Posts;

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "Can't find Post.";

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
                Posts = null;
                Response = null;
            }
        }

        public static Response Delete(int Id)
        {
            Response Response = new Response();
            Infrastructure.Models.Post Post = new Infrastructure.Models.Post();
            try
            {
              using (var db = new DatabaseContext(Helper.dbContextOptions.Options))
                {
                    Post = db.Posts.Where(x => x.Id == Id).FirstOrDefault();
                    if (Post != null)
                    {
                        Response.Status = "Success";

                        db.Posts.Remove(Post);
                        db.SaveChanges();

                        return Response;
                    }
                    else
                    {
                        Response.Status = "Success";
                        Response.Message = "Can't find Post.";

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
                Post = null;
                Response = null;
            }
        }
    }
}
