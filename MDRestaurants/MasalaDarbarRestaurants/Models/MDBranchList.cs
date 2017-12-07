using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MasalaDarbarRestaurants.Models
{
    public class MDBranchList
    {
        [Key]
        public int BranchID { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string ManagerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Email { get; set; }




    }
}