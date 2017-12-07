using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MasalaDarbarRestaurants.Models
{
    public class Reservations
    { 
        [Key]
        public int BookingID { get; set; }
        [Required(ErrorMessage ="Date is required!")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Time is required!")]
        public DateTime Time { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        public string BranchLocation { get; set; }
        [Required(ErrorMessage = "Guest Number is required!")]
        public int GuestNo { get; set; }
        [Required(ErrorMessage = "Phone Number is required!")]
        public string PhoneNo { get; set; }
        


    }
}