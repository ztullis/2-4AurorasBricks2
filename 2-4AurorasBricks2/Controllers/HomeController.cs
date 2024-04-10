using _2_4AurorasBricks2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2_4AurorasBricks2.Models;
using Microsoft.Identity.Client;

namespace _2_4AurorasBricks2.Controllers
{
    public class HomeController : Controller
    {
        public ILegoRepository _repo;

        public HomeController(ILegoRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult EditProducts()
        {
            var oneCart = _repo.Products.ToList();
            return View(oneCart);
        }

        [HttpGet]
        public IActionResult AddProducts()
        {
            var newProduct = new Product();
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult AddProducts(Product response)
        {

            _repo.AddProduct(response);
            return RedirectToAction("EditProducts");
            //if (ModelState.IsValid)
            //{
            //    _repo.AddProduct(response);
            //    return RedirectToAction("EditProducts");
            //}
            //else
            //{
            //    return View(response);
            //}
        }
        [HttpGet]
        public IActionResult EditProductsSingle(int id)
        {
            var productToEdit = _repo.Products
                .Single(x => x.ProductId == id);

            return View("AddProducts", productToEdit);
        }

        [HttpPost]
        public IActionResult EditProductsSingle(Product updatedProduct)
        {
            _repo.EditProduct(updatedProduct);

            return RedirectToAction("EditProducts");

            //if (ModelState.IsValid)
            //{
            //    _repo.EditProduct(updatedProduct);

            //    return RedirectToAction("EditProducts");
            //}
            //else
            //{
            //    return View("AddProducts", updatedProduct);
            //}
        }

        [HttpGet]
        public IActionResult DeleteProducts(int id)
        {
            var productToDelete = _repo.Products
                .Single(x => x.ProductId == id);

            return View("DeleteProducts", productToDelete);
        }

        [HttpPost]
        public IActionResult DeleteProducts(Product productToDelete)
        {
            _repo.DeleteProduct(productToDelete);

            return RedirectToAction("EditProducts");
        }
        public IActionResult EditUsers()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult ReviewOrders()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
