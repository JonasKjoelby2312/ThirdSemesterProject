﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.APIClient;

namespace ThirdSemesterProject.WebSite.Controllers;

public class ProductsController : Controller
{
    private IAPIClient _client;

    public ProductsController(IAPIClient client)
    {
        _client = client;
    }

    // GET: ProductsController
    public async Task<ActionResult> Index()
    {
        var products = await _client.GetAllProductsAsync();
        return View(products);
    }

    // GET: ProductsController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var product = await _client.GetProductByIdAsync(id);
        return View(product);
    }

    // GET: ProductsController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ProductsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: ProductsController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ProductsController/Edit/5
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

    // GET: ProductsController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ProductsController/Delete/5
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
}
