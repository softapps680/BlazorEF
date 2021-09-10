using BlazorApp.Server.Data;
//using BlazorApp.Server.Entities;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BusinessContext _context;

        public ProductsController(BusinessContext context)
        {
            _context = context;
        }

        public  IEnumerable<Product> Get()
        {
            var result =_context.Products.ToList();
            var products = new List<Product>();
            foreach(var item in result)
            {
                products.Add(new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl
                });
            }
            return products;
        }
        [Route("GetCategories")]
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            var result = _context.Categories.ToList();
            var categories = new List<Category>();
            foreach (var item in result)
            {
                categories.Add(new Category
                {
                    Id = item.Id,
                    CategoryName = item.CategoryName,
                    
                });
            }
            return categories;
        }
        [HttpGet("Edit/{id}")]
        public Product Edit(int id)
        {
            var model = _context.Products.Find(id);

            Product modelProduct = 
                
                  new Product  {
                Id=model.Id,
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                categoryId = model.categoryId
                }
                ;
            
            return modelProduct;
        }
        [HttpPost("EditProduct/{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            var entity = _context.Products.FirstOrDefault(item => item.Id == id);

            if (entity != null)
            {
                entity.Name = product.Name;
                entity.Description = product.Description;
            }


                _context.Entry(entity).State = EntityState.Modified;
             _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public void Post(Product product)
        {
            _context.Add(new Entities.Product
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                categoryId=product.categoryId
            });

            _context.SaveChanges();
        }
        [HttpGet("{id}")]
        public IEnumerable<Product> Get(int id)
        {
            var dbproducts = _context.Products.Where(x => x.categoryId == id).ToList(); ;
            var products = new List<Product>();
            foreach (var item in dbproducts)
            {
                products.Add(new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl
                });

            }

            return products;
        }
    }
}
