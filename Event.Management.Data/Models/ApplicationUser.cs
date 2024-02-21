using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Event.Management.Data.Models;
using Event_Management_Appilcation.Models;

namespace Event_Managemenent.Data.Models
{
    public class ApplicationUser : IdentityDbContext<IdentityUser>
    {
        public DbSet<SDEvent> SDEvents { get; set; }

        public DbSet<User> Users {  get; set; }

        public DbSet<UserEvent> UserEvents { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<GroupTable> Groups { get; set; }

        public DbSet<Report> Reports { get; set; }

        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {

        }

        public static void AddBaseOptions(DbContextOptionsBuilder<ApplicationUser> builder, string connectionString)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string must be provided", nameof(connectionString));

            builder.UseSqlServer(connectionString, x =>
            {
                x.EnableRetryOnFailure();
            });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureAdminGroupLeaderRelationship(builder);
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        private void ConfigureAdminGroupLeaderRelationship(ModelBuilder builder)
        {
            builder.Entity<SDEvent>(x =>
            {
                x.HasMany(e => e.UserEvents)
                    .WithOne(ue => ue.SDEvent)
                    .HasForeignKey(ue => ue.SDEventID)
                    .HasPrincipalKey(e => e.SDEventID)
                    .OnDelete(DeleteBehavior.NoAction);

                x.HasMany(e => e.GroupTables)
                  .WithOne(gt => gt.Event)
                  .HasForeignKey(e => e.EventID)
                  .HasPrincipalKey(e => e.SDEventID)
                  .OnDelete(DeleteBehavior.NoAction)
                  .IsRequired(false);
            });


            builder.Entity<UserEvent>(x =>
            {

                x.HasOne(ue => ue.User)
                    .WithMany(u => u.UserEvents)
                  
                    .OnDelete(DeleteBehavior.NoAction);

                x.HasOne(ue => ue.SDEvent)
                    .WithMany(e => e.UserEvents)
                    
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<User>(x =>
            {
                x.HasMany(u => u.UserEvents)
                    .WithOne(ue => ue.User)
                    .HasForeignKey(ue => ue.UserID)
                    .HasPrincipalKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                x.HasOne(u => u.GroupTable)
                    .WithMany(gt => gt.users)
                    .HasPrincipalKey(gt => gt.GroupID)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(u => u.GroupID);

                x.HasOne(u => u.Role)
                        .WithMany(r => r.users)
                        .HasPrincipalKey(r => r.RoleID)
                        .HasForeignKey(u => u.RoleID)
                        .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Feedback>(x =>
            {
                x.HasOne(f => f.User)
                    .WithMany(u => u.Feedbacks)
                    .HasForeignKey(f => f.UserID)
                    .HasPrincipalKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(false);


                x.HasOne(f => f.Event)
                   .WithMany(u => u.Feedbacks)
                   .HasForeignKey(f => f.EventID)
                   .HasPrincipalKey(e => e.SDEventID)
                   .OnDelete(DeleteBehavior.NoAction);
            });
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Super Admin", ConcurrencyStamp = "1", NormalizedName = "Super Admin" },
                new IdentityRole { Id = "2", Name = "Group Leader", ConcurrencyStamp = "2", NormalizedName = "Group Leader" },
                new IdentityRole { Id = "3", Name = "Team Member", ConcurrencyStamp = "3", NormalizedName = "Team Member" },
                new IdentityRole { Id = "4", Name = "User", ConcurrencyStamp = "4", NormalizedName = "User" }
            );

            
        }
    }
}
