using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Vivaldi.Api.Model;

namespace Vivaldi.DataAccess
{
   public class VivaldiDbContext : DbContext
   {
      public VivaldiDbContext() : base("VivaldiDb")
      {}

      public DbSet<MonthlyBudget> MonthlyBudget { get; set; }

      protected override void OnModelCreating(DbModelBuilder builder)
      {
         builder.Conventions.Remove<PluralizingTableNameConvention>();
      }
   }
}