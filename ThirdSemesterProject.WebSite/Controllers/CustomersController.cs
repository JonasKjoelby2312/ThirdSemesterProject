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
            ViewBag.ErrorMessage = "Incorrect Login or non exesting user";
        }
        return View();
    }

    private async Task SignInUsingClaims(List<Claim> claims)
    {
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authPropterties = new AuthenticationProperties
        {
            #region often used options - to consider including in cookie
            //AllowRefresh = <bool>,
            // Refreshing the authentication session should be allowed.

            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.

            //IsPersistent = true,
            // Whether the authentication session is persisted across 
            // multiple requests. When used with cookies, controls
            // whether the cookie's lifetime is absolute (matching the
            // lifetime of the authentication ticket) or session-based.

            //IssuedUtc = <DateTimeOffset>,
            // The time at which the authentication ticket was issued.

            //RedirectUri = <string>
            // The full path or absolute URI to be used as an http 
            // redirect response value. 
            #endregion
        };
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authPropterties);
    }

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
    public ActionResult Details()
    {
        return View();
    }
}