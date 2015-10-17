using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GroceryList.DAL
{
    public class GroceryListContext : DbContext
    {
        public GroceryListContext() : base("GroceryListContext")
        {

        }

        //prevent table names from being pluralized by EF
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}