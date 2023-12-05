using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database
{
    public class SqlDatabase : DbContext
    {
        private readonly IConfiguration _configuration;

        public SqlDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));
        }


        public DbSet<Bird> Birds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
    }
}
