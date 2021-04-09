using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DemoController : ControllerBase
    {
        private ApplicationContext db;
        public DemoController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return db.Products.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            db.Products.Add(product);
            db.SaveChanges();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var productInDb = db.Products.FirstOrDefault(x => x.Id == id);
            if (productInDb == null)
            {
                return NotFound();
            }
            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.Price = product.Price;
            db.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }

    }
}
