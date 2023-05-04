using System;
using System.Collections.Generic;

namespace ProjectSW2.Models
{
    public partial class CartStatue
    {
        public CartStatue()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string CartStatus { get; set; } = null!;

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
