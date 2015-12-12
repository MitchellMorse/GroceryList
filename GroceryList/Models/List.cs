using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        //TODO: look into viewmodels to put these into instead of in my data model
        //[NotMapped]
        //public virtual List<SelectListItem> UnusedIngredients { get; set; }
        //[NotMapped]
        //public int SelectedIngredientId { get; set; }
    }
}