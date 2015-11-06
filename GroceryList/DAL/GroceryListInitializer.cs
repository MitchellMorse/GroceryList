using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryList.Models;

namespace GroceryList.DAL
{
    public class GroceryListInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GroceryListContext>
    {
        protected override void Seed(GroceryListContext context)
        {
            var groceryStoreSections = new List<GroceryStoreSection>
            {
                new GroceryStoreSection {Id = 1, Name = "Produce" },
                new GroceryStoreSection {Id = 2, Name = "Deli" },
                new GroceryStoreSection {Id = 3, Name = "Meat" },
                new GroceryStoreSection {Id = 4, Name = "Dairy" },
                new GroceryStoreSection {Id = 4, Name = "Snack" },
            };

            groceryStoreSections.ForEach(g => context.GroceryStoreSections.Add(g));
            context.SaveChanges();

            var ingredients = new List<Ingredient>
            {
                new Ingredient { GroceryStoreSectionId = 1, Name = "Bananas"}
            };

            ingredients.ForEach(g => context.Ingredients.Add(g));
            context.SaveChanges();
        }
    }
}