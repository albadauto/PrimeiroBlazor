using Microsoft.EntityFrameworkCore;
using PrimeiroBlazor.Models;

namespace PrimeiroBlazor.API.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Games> Games { get; set; }
    }
}
