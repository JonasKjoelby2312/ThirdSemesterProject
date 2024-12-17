using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.WebSite.Controllers;

public class CustomersController : Controller
{
    IAPIClient _client;

    public CustomersController(IAPIClient client)
    {
        _client = client;
    }

    // GET: CustomerController

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    /// <summary>
    /// This method is used to Login a customer if they exist in the system.
    /// </summary>
    /// <param name="loginInfo"></param>
    /// <param name="returnUrl"></param>
    /// <returns>A succes message for login if true, else it returns error message for loggin in.</returns>
    [HttpPost]
    public async Task<ActionResult> Login([FromForm] CustomerDTO loginInfo, [FromQuery] string returnUrl)
    {
        int userId = await _client.LoginAsync(loginInfo);

        if (userId > 0)
        {
            var user = await _client.GetCustomerByIdAsync(userId);
            var claims = new List<Claim>
            {
                new Claim("user_id", user.PersonId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            await SignInUsingClaims(claims);
            TempData["Message"] = $"You are Logged In as {user.Email}";
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid Login!";
        }
        return View();
    }

    /// <summary>
    /// This method uses ASP.Net Core authentication using the identity to verify the customer.
    /// </summary>
    /// <param name="claims"></param>
    private async Task SignInUsingClaims(List<Claim> claims)
    {
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authPropterties = new AuthenticationProperties
        {   
        };
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authPropterties);
    }

    /// <summary>
    /// This method is used for loggin a customer out of the website.
    /// </summary>
    /// <returns>a message that the customer is logged out.</returns>
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        TempData["Message"] = "You are now Logged Out";
        return RedirectToAction("Index", "");
    }

    public ActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// This method creates a customer if the values in CreateCustomerAsync are vaild.
    /// </summary>
    /// <param name="customerDTO"></param>
    /// <returns>If successful the customer will be returned to the Home view and get a succes message, else a error message.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerDTO customerDTO)
    {
        try
        {
            if (await _client.CreateCustomerAsync(customerDTO) > 0)
            {
                TempData["Message"] = $"User {customerDTO.Email} Created!";
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "User not created!";
            }
        }
        catch (Exception ex)
        {

            ViewBag.ErrorMessage = ex.Message;
        }
        return View();
    }
    
    /// <summary>
    /// This method is used for seeing the details about the logged in customer.
    /// </summary>
    /// <returns>A view of the customer details</returns>
    public async Task<ActionResult> Details()
    {
        int id = Int32.Parse(User.Claims.Where(claim => claim.Type == "user_id").Select(claim => claim.Value).SingleOrDefault());
        var customer = await _client.GetCustomerByIdAsync(id);
        return View(customer);
    }

    /// <summary>
    /// This method is used for getting all saleOrders associated with a customer.
    /// </summary>
    /// <param name="customerId">Using the customerId to find the saleOrders for the customer.</param>
    /// <returns>A view with the customers saleOrders.</returns>
    [HttpGet("Customers/{customerId}/SaleOrders")]
    public async Task<ActionResult<IEnumerable<SaleOrderDTO>>> SaleOrders(int customerId)
    {
        var customer = await _client.GetCustomerByIdAsync(customerId);
        var saleOrders = await _client.GetAllSaleOrdersByPersonIdAsync(customerId);
        return View(saleOrders);
    }
}