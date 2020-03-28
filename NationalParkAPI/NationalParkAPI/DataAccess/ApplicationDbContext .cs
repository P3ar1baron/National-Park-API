using Microsoft.EntityFrameworkCore;
using NationalParkAPI.Models;

namespace NationalParkAPI.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<NationalParkDto> NationalParks { get; set; }
    }
}
