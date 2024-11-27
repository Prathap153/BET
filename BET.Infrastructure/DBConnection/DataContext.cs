using BET.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BET.Infrastructure.DBConnection
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<BusinessUnit> businessUnit { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<BillGenerated> billGenerated { get; set; }
        public DbSet<Income> income { get; set; }
        public DbSet<Expenses> expenses { get; set; }
        public DbSet<Payments> payments { get; set; }

    }
}
