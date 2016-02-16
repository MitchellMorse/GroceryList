using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryList.Models;

namespace GroceryList.ViewModels
{
    public class ListIngredients
    {
        public List CurrentList { get; set; }

        public int CurrentListId { get; set; }

        public virtual List<SelectListItem> UnusedIngredients { get; set; }

        public virtual List<Ingredient> AddedIngredients { get; set; }

        public int SelectedIngredientId { get; set; }
    }
}