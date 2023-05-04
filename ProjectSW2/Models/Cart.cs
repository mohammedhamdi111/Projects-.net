using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSW2.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartStatusId { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public virtual CartStatue CartStatus { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual User user { get; set; }
    }
}
