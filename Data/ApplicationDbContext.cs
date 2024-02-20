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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Chellew",
                    Email = "Jamespchellew@outlook.com",
                    PhoneNumber = "0432665009",
                    PhotoUrl = "",
                    CreatedTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Ash",
                    LastName = "T",
                    Email = "Ash@outlook.com",
                    PhoneNumber = "0412312312",
                    PhotoUrl = "",
                    CreatedTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Liam",
                    LastName = "p",
                    Email = "Liam@outlook.com",
                    PhoneNumber = "0409987987",
                    PhotoUrl = "",
                    CreatedTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                });
        }
    }
}
