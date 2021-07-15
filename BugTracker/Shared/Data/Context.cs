using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BugTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Shared.Data
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public Context() : base("Context")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Removing our pluralizing table name convention
            // so our table names will use our entity class singular names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            // Using the fluent API to configure entity properties...
            
            // Configure the string length for the Bug.Name property.
            modelBuilder.Entity<Bug>()
                .Property(a => a.Name)
                .HasMaxLength(100);
        }
    }
}