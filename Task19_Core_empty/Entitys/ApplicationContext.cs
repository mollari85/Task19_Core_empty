using Microsoft.EntityFrameworkCore;
using Task19_Core_empty.Models;

namespace Task19_Core_empty.Entitys
{
    public class ApplicationContext:DbContext
    {
        public DbSet<PersonInfo> Persons => Set<PersonInfo>();
        public ApplicationContext()=>Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile($"Properties\\launchSettings.json", true, true)
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnectionSQL"));
        }
    }
}
