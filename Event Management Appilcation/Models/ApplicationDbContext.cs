using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_Appilcation.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }



        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Super Admin", ConcurrencyStamp = "1", NormalizedName = "Super Admin" },
                new IdentityRole() { Name = "Group Leader", ConcurrencyStamp = "2", NormalizedName = "Group Leader" },
                new IdentityRole() { Name = "Team Leader", ConcurrencyStamp = "3", NormalizedName = "Team Leader" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "4", NormalizedName = "User" }


                );
        }
    }
}