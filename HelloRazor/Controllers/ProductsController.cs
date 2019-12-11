using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloRazor.Models;
using HelloRazor.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloRazor.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        // GET api/values/5
        [HttpGet("Rate")]
        public ActionResult Get(
            [FromQuery]string productId,
            [FromQuery]int Rating)
        {
            ProductService.AddRating(productId, Rating);
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
