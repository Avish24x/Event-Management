using Event_Management_Appilcation.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_Appilcation.Interfaces
{
    public class DesignTimeUserDbContextFactory : IDesignTimeDbContextFactory<ApplicationUser>
    {
        public ApplicationUser CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            IConfigurationBuilder builder =
                new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("ConnStr");

            Console.WriteLine($"DesignTimeDbContextFactory: using base path = {path}");
            Console.WriteLine($"DesignTimeDbContextFactory: using connection string = {connectionString}");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Could not find connection string named 'ConnStr'");
            }

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationUser>();

            ApplicationUser.AddBaseOptions(dbContextOptionsBuilder, connectionString);

            return new ApplicationUser(dbContextOptionsBuilder.Options);
        }
    }
}
