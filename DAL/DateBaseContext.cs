using Microsoft.EntityFrameworkCore;
using webapitest.DAL.Entities;

namespace webapitest.DAL
{
    public class DateBaseContext : DbContext
    {
        public DateBaseContext(DbContextOptions<DateBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }
        #region Dbsets
        public DbSet<Country> Countries { get; set; }
        #endregion
    }
}
