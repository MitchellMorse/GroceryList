using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroceryList.Models
{
    public class ListIngredient
    {
        public int Id { get; set; }
        [ForeignKey("Ingredient")]
        [Display(Name = "Ingredient")]
        public int IngredientId { get; set; }
        [ForeignKey("List")]
        [Display(Name = "List")]
        public int ListId { get; set; }
        public bool Retrieved { get; set; }

        public virtual List Lint { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}