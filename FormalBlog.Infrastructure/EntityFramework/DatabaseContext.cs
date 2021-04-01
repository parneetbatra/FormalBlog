using FormalBlog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FormalBlog.Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
