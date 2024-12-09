using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;

//using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebSite.Models;

namespace ThirdSemesterProject.WebSite.Controllers;

public class CartController : Controller
{
    private IAPIClient _client;

    public CartController(IAPIClient client)
    {
        _client = client;
    }

    // GET: CartController
    public ActionResult Index()
    {
        return View(GetCartFromCookie());
    }

    public IAPIClient GetClient()
    {
        return _client;
    }

    // GET: CartController/Add/5?quantity=3
    public async Task<ActionResult> Add(int id, int quantity, bool returnToCart = false)
    {
        ProductDTO productDTO = await _client.GetProductByIdAsync(id);
        var cart = LoadChangeAndSaveCart(cart => cart.ChangeQuantity(new ProductQuantity(productDTO, quantity)));

        if (returnToCart)
        {
            return View("Index", cart);
        }
        return RedirectToAction("Index", "Products");
    }

    // GET: CartController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }
    
    // GET: CartController/Create
    public ActionResult Create()
    {

        return View();
    }

    // POST: CartController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]  
    public async Task<ActionResult> Create(SaleOrderDTO saleOrderDTO)
    {
        try
        {
            saleOrderDTO.CustomerDTO.PersonId = Int32.Parse(User.Claims.Where(c => c.Type == "user_id").Select(c => c.Value).SingleOrDefault());
            await CartToSaleOrder(saleOrderDTO);
            await _client.CreateSaleOrderAsync(saleOrderDTO);
            EmptyCart();

            TempData["SuccessMessage"] = "Your order was successfully placed!";
            return RedirectToAction("Index", "Home");
        }
        catch
        {
            TempData["ErrorMessage"] = $"An error occurred while placing your order";
            return RedirectToAction(nameof(Create));
        }
    }

    private async Task<SaleOrderDTO> CartToSaleOrder(SaleOrderDTO saleOrderDTO)
    {
        Cart cart = GetCartFromCookie();
        foreach (ProductQuantity item in cart.ProductQuantities.Values)
        {
            
            saleOrderDTO.OrderLines.Add(new OrderLineDTO() { Quantity = item.Quantity, UnitPrice = item.Price, ProductDTO = new ProductDTO { ProductId = item.Id, CurrentStock = 0, Description = "", Name = "", ProductType = "", Color = "", SalesPrice = 100, Size = "", Weight = 2 }});

        }
        return saleOrderDTO;
    }

    // GET: CartController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CartController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CartController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CartController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult EmptyCart()
    {
        var cart =  LoadChangeAndSaveCart(cart => cart.EmptyAll());
        return RedirectToAction("Index", cart);
        
    }

    private Cart LoadChangeAndSaveCart(Action<Cart> action)
    {
        Cart cart = GetCartFromCookie();
        action(cart);
        ViewBag.Cart = cart;
        SaveCartToCookie(cart);
        return cart;
    }

    private Cart GetCartFromCookie()
    {
        Request.Cookies.TryGetValue("Cart", out string? cookie);
        if (cookie == null)
        {
            return new Cart();
        }
        return JsonSerializer.Deserialize<Cart>(cookie) ?? new Cart();
    }

    private void SaveCartToCookie(Cart cart)
    {
        var cookieOptions = new CookieOptions();
        cookieOptions.Expires = DateTime.Now.AddDays(14);
        cookieOptions.Path = "/";
        Response.Cookies.Append("Cart", JsonSerializer.Serialize(cart), cookieOptions);
    }
}