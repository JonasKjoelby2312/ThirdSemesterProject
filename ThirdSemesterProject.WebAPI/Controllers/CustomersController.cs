using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebAPI.DTOs;
using ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        ICustomerDAO _customerDAO;
        private IMapper _mapper;
       
        public CustomersController(ICustomerDAO customerDAO, IMapper mapper)
        {
            
            _customerDAO = customerDAO;
            _mapper = mapper;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        //This method is used for getting a customer by id, it takes an id in the paramater. 
        //The method returns a customer. 
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


        //The post method, are used for creating customers on the website. 
        //The method takes a CustomerDTO object, and uses the NuGet package AutoMapper, to map from DTO to model class. 
        //The method returns the newly created ID from the database. 

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerDTO newCustomerDTO)
        {
            
            var customerToMap = _mapper.Map<CustomerDTO, Customer>(newCustomerDTO);
            var customerId = await _customerDAO.CreateAsync(customerToMap, newCustomerDTO.Password);
            return Ok(customerId);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
