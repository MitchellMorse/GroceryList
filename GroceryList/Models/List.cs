using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryList.Models
{
    public class List
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date)] 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<ListIngredient> ListIngredients { get; set; } 
    }
}