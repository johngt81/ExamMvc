using Exam.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Exam.Repository
{
    public class SalesDbContext:DbContext
    {
        public SalesDbContext()
            :base("NetFundamentals")
        {
            Database.SetInitializer<SalesDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
