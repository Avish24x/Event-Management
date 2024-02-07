using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_Appilcation.Models
{
    public class ApplicationUser : IdentityDbContext<IdentityUser>


    {
        public DbSet<GroupLeader> GroupLeaders { get; set; }
        public DbSet<AdminGroupLeader> AdminGroupLeaders { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Admin> Admins { get; set; }

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
            base.OnModelCreating(builder);
            ConfigureAdminGroupLeaderRelationship(builder);
            SeedRoles(builder);
        }

        private void ConfigureAdminGroupLeaderRelationship(ModelBuilder builder)
        {
            builder.Entity<AdminGroupLeader>()
                .HasKey(agl => new { agl.AdminID, agl.GroupLeaderID });

            builder.Entity<AdminGroupLeader>()
                .HasOne(agl => agl.Admin)
                .WithMany(admin => admin.AdminGroupLeaders)
                .HasForeignKey(agl => agl.AdminID)
                .HasPrincipalKey(admin => admin.AdminID);

            builder.Entity<AdminGroupLeader>()
                .HasOne(agl => agl.GroupLeader)
                .WithMany(groupLeader => groupLeader.AdminGroupLeaders)
                .HasForeignKey(agl => agl.GroupLeaderID)
                .HasPrincipalKey(groupLeader => groupLeader.GroupLeaderID);

            builder.Entity<Event>(x =>
            {
                x.HasOne(e => e.GroupLeader)
                    .WithMany(gl => gl.Events)
                    .HasForeignKey(e => e.GroupLeaderID)
                    .HasPrincipalKey(gl => gl.GroupLeaderID)
                    .OnDelete(DeleteBehavior.NoAction);

                x.HasOne(e => e.TeamMember)
                    .WithMany(tm => tm.Events)
                    .HasForeignKey(e => e.TeamMemberID)
                    .HasPrincipalKey(tm => tm.TeamMemberID)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<UserEvent>()
                .HasKey(ue => new { ue.UserID, ue.EventID });

            builder.Entity<User>(x =>
            {
                x.HasMany(u => u.UserEvents)
                    .WithOne(ue => ue.User)
                    .HasForeignKey(ue => ue.UserID)
                    .HasPrincipalKey(u => u.Id)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Event>(x =>
            {
                x.HasMany(u => u.UserEvents)
                    .WithOne(ue => ue.Event)
                    .HasForeignKey(ue => ue.EventID)
                    .HasPrincipalKey(u => u.EventID)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<GroupTable>(x =>
            {
                x.HasOne(g => g.GroupLeader)
                    .WithOne(gl => gl.Group)
                    .HasForeignKey<GroupLeader>(gl => gl.GroupID)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Feedback>(x =>
            {
                x.HasOne(f => f.User)
                    .WithMany(u => u.Feedbacks)
                    .HasForeignKey(f => f.UserID)
                    .HasPrincipalKey(u => u.Id)
                    .OnDelete(DeleteBehavior.NoAction);

                x.HasOne(f => f.Event)
                   .WithMany(u => u.Feedbacks)
                   .HasForeignKey(f => f.EventID)
                   .HasPrincipalKey(u => u.EventID)
                   .OnDelete(DeleteBehavior.NoAction);


                builder.Entity<Report>(entity =>
                {
                    entity.HasKey(r => r.ReportID);
                    entity.Property(r => r.Title).IsRequired();
                    entity.Property(r => r.DateGenerated).IsRequired();
                    // Add other configurations as needed...
                });
            }); 

        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Super Admin", ConcurrencyStamp = "1", NormalizedName = "Super Admin" },
                new IdentityRole { Id = "2", Name = "Group Leader", ConcurrencyStamp = "2", NormalizedName = "Group Leader" },
                new IdentityRole { Id = "3", Name = "Team Leader", ConcurrencyStamp = "3", NormalizedName = "Team Leader" },
                new IdentityRole { Id = "4", Name = "User", ConcurrencyStamp = "4", NormalizedName = "User" }
            );
        }
    }
}
