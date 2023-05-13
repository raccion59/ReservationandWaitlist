using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class ReservadoContext :DbContext
    {
        protected readonly IConfiguration _configuration;

        public ReservadoContext(IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

            //base.OnConfiguring(optionsBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessUser> BusinessUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Faq> Faqs{ get; set; }
        public DbSet<Photo> Photos{ get; set; }
        public DbSet<Review> Reviews { get; set; }



    }
}
