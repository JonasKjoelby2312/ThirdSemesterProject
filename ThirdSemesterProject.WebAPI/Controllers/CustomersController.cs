using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebAPI.DTOs;
using ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers
{
    /// <summary>
    /// Handles customer-related API operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        ICustomerDAO _customerDAO;
        private IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="customerDAO">Data Access Object for customer operations.</param>
        /// <param name="mapper">AutoMapper instance for mapping between DTOs and models.</param>
        public CustomersController(ICustomerDAO customerDAO, IMapper mapper)
        {
            
            _customerDAO = customerDAO;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>An <see cref="ActionResult"/> containing the customer's details.</returns>
        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> Get(int id)
        {
            return Ok(await _customerDAO.GetByIdAsync(id));
        }


        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="newCustomerDTO">The data transfer object containing new customer details.</param>
        /// <returns>The unique identifier of the created customer.</returns>
        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerDTO newCustomerDTO)
        {
            
            var customerToMap = _mapper.Map<CustomerDTO, Customer>(newCustomerDTO);
            var customerId = await _customerDAO.CreateAsync(customerToMap, newCustomerDTO.Password);
            return Ok(customerId);
        }
    }
}
