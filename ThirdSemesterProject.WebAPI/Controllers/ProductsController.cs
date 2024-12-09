using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDAO _productsDAO;

        public ProductsController(IProductDAO dao)
        {
            _productsDAO = dao;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {
            return Ok(await _productsDAO.GetAllAsync());
        }


        //This method is used for finding a product by ID, it takes an id in the paramater. 
        //The method returns a product. 
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get([FromRoute] int id)
        {
            var foundProductById = await _productsDAO.GetByIdAsync(id);
            if (foundProductById == null)
            {
                return NotFound();
            }
            
            return Ok(foundProductById);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Product product)
        {
            return Ok(await _productsDAO.CreateAsync(product));
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
