using Microsoft.EntityFrameworkCore;
using RatingAPI.Entities;
using RatingAPI.Enums;

namespace RatingAPI.DBContext

{
    public class BillsContext : DbContext
    {
        public DbSet<Bills> Bills { get; set; }
        public DbSet<User> User { get; set; }
        public BillsContext(DbContextOptions<BillsContext> options) : base(options) //Llama constructor db context
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new User[2] {
                new User()
                {
                    Id = 1,
                    Name = "julian",
                    SurName = "abdala",
                    Password = "juli123",
                    UserName = "turco",
                    UserType = Permissions.administrator

                },
                 new User()
                {
                    Id = 2,
                    Name = "lola",
                    SurName = "gato",
                    Password = "catchow",
                    UserName = "pipi",
                    UserType = Permissions.defaultuser

                },

            };
            modelBuilder.Entity<User>().HasData(user);
            base.OnModelCreating(modelBuilder);
        }*/
    }
}

    
