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

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> Get(int id)
        {
            return Ok(await _customerDAO.GetByIdAsync(id));
        }

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
