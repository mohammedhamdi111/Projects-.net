using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSW2.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Rate { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}
