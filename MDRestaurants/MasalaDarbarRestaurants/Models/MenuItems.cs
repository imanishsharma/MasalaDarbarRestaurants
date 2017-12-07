using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MasalaDarbarRestaurants.Models
{
    public class MenuItems
    {   [Key]
        public int ItemID { get; set; }
        [Required(ErrorMessage="Item Name is Required!")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Item Detail is Required!")]
        public string ItemDetail { get; set; }
        [Required(ErrorMessage = "Item Price is Required!")]
        public double ItemPrice { get; set; }
        public string ItemImage { get; set; }
    }
}