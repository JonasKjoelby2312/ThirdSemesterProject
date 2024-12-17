using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebSite.Models;

namespace ThirdSemesterProject.WebSite.Controllers;

public class CartController : Controller
{
    private IAPIClient _client;

    /// <summary>
    /// Creates a variable of IAPIClient using dependency injection.
    /// </summary>
    /// <param name="client">Takes the IAPIClient and names it client.</param>
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

    /// <summary>
    /// This method Adds a product to the cart.
    /// </summary>
    /// <param name="id">Uses product id.</param>
    /// <param name="quantity">adds the quantity for the product added to the cart.</param> ????
    /// <param name="returnToCart">???</param>
    /// <returns>the cart index view</returns>
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
    //slettes?
    // GET: CartController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }
    //slettes?
    // GET: CartController/Create
    public ActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// This method uses a customer with id needed to create a saleOrder.
    /// </summary>
    /// <param name="saleOrderDTO"></param>
    /// <returns>a success message if the order is created, else it catch an error message if it failed.</returns>
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

    /// <summary>
    /// This method creates a saleOrder when a product is added and a orderLines is created.
    /// </summary>
    /// <param name="saleOrderDTO"></param>
    /// <returns>SaleOrder.</returns>
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

    /// <summary>
    /// This method is used for deleting a orderline from the cart.
    /// </summary>
    /// <param name="id">uses the product id to delete</param>
    /// <param name="collection"></param>
    /// <returns>The cart view with one less product or deletes the whole orderLine if it is 0. </returns>
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

    /// <summary>
    /// This method is used for empting the whole cart.
    /// </summary>
    /// <returns>returns the cart view with an empty cart</returns>
    public ActionResult EmptyCart()
    {
        var cart =  LoadChangeAndSaveCart(cart => cart.EmptyAll());
        return RedirectToAction("Index", cart);
    }

    /// <summary>
    /// This method is used to load and save the cart when something is delted or added to the cart.
    /// </summary>
    /// <param name="action"></param>
    /// <returns>the updated cart</returns>
    private Cart LoadChangeAndSaveCart(Action<Cart> action)
    {
        Cart cart = GetCartFromCookie();
        action(cart);
        ViewBag.Cart = cart;
        SaveCartToCookie(cart);
        return cart;
    }

    /// <summary>
    /// This method is responsible for retrieving and deserializing a shopping cart object (Cart) from a browser cookie.
    /// </summary>
    private Cart GetCartFromCookie()
    {
        Request.Cookies.TryGetValue("Cart", out string? cookie);
        if (cookie == null)
        {
            return new Cart();
        }
        return JsonSerializer.Deserialize<Cart>(cookie) ?? new Cart();
    }

    //This method is used for saving the current cart.
    private void SaveCartToCookie(Cart cart)
    {
        var cookieOptions = new CookieOptions();
        cookieOptions.Expires = DateTime.Now.AddDays(14);
        cookieOptions.Path = "/";
        Response.Cookies.Append("Cart", JsonSerializer.Serialize(cart), cookieOptions);
    }
}