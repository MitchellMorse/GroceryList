using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GroceryList.Models;

namespace GroceryList.DAL
{
    public class GroceryListContext : DbContext
    {
        public GroceryListContext() : base("GroceryListContext")
        {
            this.Database.Connection.ConnectionString =
                "Data Source=localhost;Initial Catalog=GroceryList;Integrated Security=SSPI;MultipleActiveResultSets=True";
        }

        public DbSet<List> Lists { get; set; }
        public DbSet<GroceryStoreSection> GroceryStoreSections { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ListIngredient> ListIngredients { get; set; }

        //prevent table names from being pluralized by EF
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}