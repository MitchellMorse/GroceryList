using System.Collections.Generic;
using GroceryList.Models;

namespace GroceryList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GroceryList.DAL.GroceryListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GroceryList.DAL.GroceryListContext context)
        {
            var groceryStoreSections = new List<GroceryStoreSection>
            {
                new GroceryStoreSection {Id = 1, Name = "Produce" },
                new GroceryStoreSection {Id = 2, Name = "Deli" },
                new GroceryStoreSection {Id = 3, Name = "Meat" },
                new GroceryStoreSection {Id = 4, Name = "Dairy" },
                new GroceryStoreSection {Id = 5, Name = "Snack" },
                new GroceryStoreSection {Id = 6, Name = "Bakery" },
                new GroceryStoreSection {Id = 7, Name = "Bread" }
            };

            groceryStoreSections.ForEach(g => context.GroceryStoreSections.Add(g));
            context.SaveChanges();

            var ingredients = new List<Ingredient>
            {
                new Ingredient { GroceryStoreSectionId = 1, Name = "Bananas"},
                new Ingredient { GroceryStoreSectionId = 7, Name = "Wheat bread"},
                new Ingredient { GroceryStoreSectionId = 7, Name = "White bread"},
                new Ingredient { GroceryStoreSectionId = 4, Name = "Sliced cheese"},
                new Ingredient { GroceryStoreSectionId = 1, Name = "Salad"}
            };

            ingredients.ForEach(g => context.Ingredients.Add(g));
            context.SaveChanges();
        }
    }
}
