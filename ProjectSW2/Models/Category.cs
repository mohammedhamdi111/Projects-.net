using System;
using System.Collections.Generic;

namespace ProjectSW2.Models
{
    public partial class Category
    {
      

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        
    }
}
