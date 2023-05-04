using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSW2.Models
{
    public partial class OrderTable
    {
       
        public int Id { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public bool IsDelivered { get; set; }
        public  Address? Address { get; set; } = null!;
        public  User? user { get; set; }
   
    }
}
