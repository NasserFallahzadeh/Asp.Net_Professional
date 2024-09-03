using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models.Entities;
using WebAppMvc.Models.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductApiController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        // GET api/<ProductApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productService.GetById(id));
        }

        // POST api/<ProductApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            return Ok(_productService.Add(value));
        }

        // PUT api/<ProductApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<ProductApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Remove(id);
            return Ok(true);
        }
    }
}
