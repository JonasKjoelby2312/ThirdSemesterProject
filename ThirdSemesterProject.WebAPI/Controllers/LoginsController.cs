using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.WebAPI.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {

        ICustomerDAO _customerDAO;
        public LoginsController(ICustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerDTO loginValues)
        {
            return await _customerDAO.LoginAsync(loginValues.Email, loginValues.Password);
        }
    }
}
