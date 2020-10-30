using Microsoft.EntityFrameworkCore;
using QuasarLite.Models;
using System;

namespace QuasarLite.DbContexts
{
    public class XContext : DbContext
    {
        public XContext(DbContextOptions<XContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "JohnDoe469",
                    Name = "John",
                    Surname = "Doe",
                    Email = "johndoe@xmail.com",
                    Password = "1234",
                    CreateDate = DateTime.UtcNow
                }
                );
        }

        public DbSet<User> Users { get; set; }
    }
}
