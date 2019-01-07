using projetoWhois.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace projetoWhois.DAL
{
    public class WhoisContext : DbContext
    {
        public WhoisContext() : base("WhoisContext")
        {
            Database.SetInitializer<WhoisContext>(new CreateDatabaseIfNotExists<WhoisContext>());
        }

        public DbSet<WhoisInfo> WhoisInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}