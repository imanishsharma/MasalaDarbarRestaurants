using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MasalaDarbarRestaurants.Models
{
    public class MasalaDarbarDbContext : DbContext
    {
        public DbSet<CustomerDetail> customerDetails { get; set; }
        public DbSet<Reservations> reservationDetails { get; set; }
        public DbSet<MDBranchList> branchesDetails { get; set; }
        public DbSet<MenuItems> menuitemsDetails { get; set; }
      }



}