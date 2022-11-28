using CountriesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CountriesApp.Data
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions<CountryDbContext> options): base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
    }
}
