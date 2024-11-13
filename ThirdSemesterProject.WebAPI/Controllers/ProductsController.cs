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
        IDAO<Product> _productsDAO;

        public ProductsController(IDAO<Product> dao)
        {
            _productsDAO = dao;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productsDAO.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get([FromRoute] int id)
        {
            var foundProductById = _productsDAO.GetById(id);
            if (foundProductById == null)
            {
                return NotFound();
            }
            foundProductById.ProductId = id;
            return Ok(foundProductById);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Product product)
        {
            return Ok( _productsDAO.Create(product));
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
