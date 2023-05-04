using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSW2.Models
{
    public partial class Address
    {
        public Address()
        {
            OrderTables = new HashSet<OrderTable>();
        }

        public int Id { get; set; }
        public string StreetNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = null!;

        public string PostalCode { get; set; } = null!;
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}
