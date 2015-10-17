using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroceryList.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [ForeignKey("GroceryStoreSection")]
        [Display(Name = "Grocery Store Section")]
        public int GroceryStoreSectionId { get; set; }

        public virtual GroceryStoreSection GroceryStoreSection { get; set; }
    }
}