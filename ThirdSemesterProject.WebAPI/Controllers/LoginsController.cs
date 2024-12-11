using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.WebAPI.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers
{
    /// <summary>
    /// Handles login-related API operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {

        ICustomerDAO _customerDAO;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginsController"/> class.
        /// </summary>
        /// <param name="customerDAO">Data Access Object for customer operations.</param>
        public LoginsController(ICustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        /// <summary>
        /// This method authenticates a customer based on email and password.
        /// </summary>
        /// <param name="loginValues">A <see cref="CustomerDTO"/>Containing a Customers Login credentials.</param>
        /// <returns>
        /// An <see cref="ActionResult"/> Containing identifier(int) of the authenticated Customer.
        /// In the APIClient it throws a HttpRequestException if the login values does not match, and returns a login failed and the response message.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerDTO loginValues)
        {
            return await _customerDAO.LoginAsync(loginValues.Email, loginValues.Password);
        }
    }
}
