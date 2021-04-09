using System;
using System.ComponentModel.DataAnnotations;

namespace FormalBlog.Infrastructure.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string MetaImage { get; set; }
        public string MetaDesciption { get; set; }
        public string MetaKeywords { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Datetime { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool Trash { get; set; }

        public DateTime? TrashDatetime { get; set; }
    }
}
