using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalBlog.Infrastructure.Models
{
    [Table("Subscribers")]
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public string VerificationCode { get; set; }

        public bool Verified { get; set; }

        public DateTime Datetime { get; set; }

        public bool Subscribed { get; set; }
    }
}
