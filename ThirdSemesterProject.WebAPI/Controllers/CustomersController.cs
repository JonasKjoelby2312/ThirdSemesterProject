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
        ///This method is used for getting a customer by id, it takes an id in the paramater. 
        ///The method returns a customer. 
        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var foundCustomer = await _customerDAO.GetByIdAsync(id);
            if (foundCustomer != null)
            {
                return Ok(foundCustomer);
            }
            return NotFound();
        }

        //rettes?
        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="newCustomerDTO">The data transfer object containing new customer details.</param>
        /// <returns>The unique identifier of the created customer.</returns>
        ///The post method, are used for creating customers on the website. 
        ///The method takes a CustomerDTO object, and uses the NuGet package AutoMapper, to map from DTO to model class. 
        ///The method returns the newly created ID from the database. 
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