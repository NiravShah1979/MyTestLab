using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTestWeb.Models
{
    public class Item
    {
        public string ItemCode { get; set; }

        [Display(Name = "Name")]
        public string ItemName { get; set; }

        [DataType(DataType.Currency)]
        public string Price { get; set; }
    }
}