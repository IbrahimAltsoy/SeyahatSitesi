using Microsoft.EntityFrameworkCore;
using SeyahatSitesi.Models;

namespace SeyahatSitesi.Models.Class
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        
        
        public DbSet<About> Abouts { get; set; }       
        public DbSet<Address> Adresss { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }

       

    }
}
