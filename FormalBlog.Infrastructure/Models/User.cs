using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormalBlog.Infrastructure.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool EmailVerified { get; set; }
        public string EmailVerificationCode { get; set; }
        public int? EmailVerificationCodeDate { get; set; }

        [Required]
        public string Password { get; set; }
        public string ResetPasswordCode { get; set; }
        public int? ResetPasswordCodeDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }

        [Required]
        public bool Active { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
