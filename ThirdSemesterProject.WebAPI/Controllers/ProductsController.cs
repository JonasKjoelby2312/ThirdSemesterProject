using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers
{

    /// <summary>
    /// APIController for managing Product related operations. 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDAO _productsDAO;


        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class
        /// And sets up dependency on a product data access object.
        /// </summary>
        /// <param name="dao"></param> The data access object product, and is used for database operations.</param>
        public ProductsController(IProductDAO dao)
        {
            _productsDAO = dao;
        }

        /// <summary>
        /// This HttpGet is used to retrive all products.
        /// </summary>
        /// <returns>
        /// A List of all the products in the database.
        /// </returns>
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {
            return Ok(await _productsDAO.GetAllAsync());
        }

        //rettes?
        /// <summary>
        /// This HttpGet is used to get a single product from the database with given id.
        /// </summary>
        /// <param name="id">The identifyer for the product </param>
        /// <returns> 
        /// Returns a product from the database, if it does not exsist it will throw a 404 error not found.
        /// </returns>
        ///This method is used for finding a product by ID, it takes an id in the paramater. 
        ///The method returns a product. 
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

        /// <summary>
        /// This HttpPost adds a new product to the database.
        /// </summary>
        /// <param name="product">The product to add</param>
        /// <returns>
        /// The newly created product with an indentifyer. 
        /// </returns>
        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Product product)
        {
            return Ok(await _productsDAO.CreateAsync(product));
        }
    }
}
