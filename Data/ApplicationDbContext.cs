using LolFantasy.Models;
using Microsoft.EntityFrameworkCore;

namespace LolFantasy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User()
        //        {
        //            Id = 1,
        //            FirstName = "James",
        //            LastName = "Chellew",
        //            Email = "Jamespchellew@outlook.com",
        //            PhoneNumber = "0432665009",
        //            PhotoUrl = "",
        //            CreatedTime = DateTime.Now,
        //            UpdateTime = DateTime.Now,
        //        });
        //}
    }
}
