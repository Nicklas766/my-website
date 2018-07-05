using my_website.Models;
using Microsoft.EntityFrameworkCore;

namespace my_website.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}