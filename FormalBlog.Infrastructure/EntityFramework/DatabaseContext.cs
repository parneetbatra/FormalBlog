using FormalBlog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FormalBlog.Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext()
        //{

        //}

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string MySqlConnectionString = "";

        //    optionsBuilder.UseMySql(MySqlConnectionString, ServerVersion.AutoDetect(MySqlConnectionString), b => b.MigrationsAssembly("FormalBlog.Infrastructure"));
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subscribe> Subscribers { get; set; }
    }
}
