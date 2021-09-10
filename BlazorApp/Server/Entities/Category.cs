using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Entities
{
    public class Category
    {
        [Key]
        public int Id {get;set;}
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
