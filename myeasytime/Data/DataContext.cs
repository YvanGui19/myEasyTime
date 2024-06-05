using Microsoft.EntityFrameworkCore;
using myeasytime.Models;

namespace myeasytime.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Conge> Conges { get; set; }
    }
}
