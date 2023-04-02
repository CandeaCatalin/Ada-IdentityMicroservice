using IdentityMicroservice.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IdentityMicroservice.DataAccess
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var defaultUserRoles = new List<IdentityRole>()
            {
                new IdentityRole("Admin"){NormalizedName = "ADMIN"},
                new IdentityRole("User"){NormalizedName = "USER"}
            };
            
            modelBuilder.Entity<IdentityRole>().HasData(defaultUserRoles);
            base.OnModelCreating(modelBuilder);

        }
    }
}