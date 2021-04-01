

namespace FormalBlog.Infrastructure.ViewModels.User
{
    public class Signup
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool AcceptTerms { get; set; }
        public string LastLoginIP { get; set; }
    }
}
