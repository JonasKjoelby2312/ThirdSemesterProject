using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.WebSite.Controllers
{
    public class SaleOrdersController : Controller
    {



        IAPIClient _client;

        public SaleOrdersController(IAPIClient client)
        {
            _client = client;
        }

        // GET: SaleOrdersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleOrdersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var orderLinesWithProducts = await _client.GetAllOrderLinesWithProductsBySaleOrderIdAsync(id);

            return View(orderLinesWithProducts);
        }

        // GET: SaleOrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleOrdersController/Create
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

        // GET: SaleOrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleOrdersController/Edit/5
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

        // GET: SaleOrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleOrdersController/Delete/5
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
}
