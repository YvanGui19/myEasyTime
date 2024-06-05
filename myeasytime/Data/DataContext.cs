using Microsoft.EntityFrameworkCore;
using myeasytime.Models;
using System;

namespace myeasytime.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Conge> Conges { get; set; }

        public DbSet<DemandeConge> DemandesConges { get; set; }
    }

}
