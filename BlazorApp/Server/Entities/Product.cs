using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Server.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int categoryId { get; set; }
      
        public Category Category { get; set; }

        
    }
}
