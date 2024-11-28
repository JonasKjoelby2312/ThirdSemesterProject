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
        // GET: SaleOrdersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleOrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
