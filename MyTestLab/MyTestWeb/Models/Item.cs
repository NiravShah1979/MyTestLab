using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTestWeb.Models
{
    public class Item 
    {
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Name")]
        public string ItemName { get; set; }

        public IEnumerable<SelectListItem> ItemTypes { get; set; }

        public string SelectedItemType { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Currency)]
        public string Price { get; set; }
    }
}