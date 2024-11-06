using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Project.Models.Data;

namespace E_Project.Models.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
       /* public DbSet<Admin> admins { get; set; }/*///Table Name (Employees)
        public DbSet<ContactUs> contacts { get; set; }
        public DbSet<Donations> donations { get; set; }
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Partners> partners { get; set; }
        public DbSet<Programmes> programmes { get; set; }
        public DbSet<AssociatedNGOs> AssociatedNGOs { get; set; }
        //public DbSet<Transactions> transactions { get; set; }
      
      
    }
}
