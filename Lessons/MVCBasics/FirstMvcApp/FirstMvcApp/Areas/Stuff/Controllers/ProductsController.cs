using FirstMvcApp.Models;
using FirstMvcApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Areas.Stuff.Controllers
{
    [Area("Stuff")]
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        // GET: ProductsController
        //[HttpGet]
        //[HttpGet("Index")]
        public ActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        // GET: ProductsController/Details/5
        //[HttpGet("Details/{id:int}")]
        public ActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        //public ActionResult Any(string any)
        //{
        //    return Content("You hit products any action!");
        //}


        // GET: ProductsController/Create
        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _productService.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        [HttpGet("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                _productService.UpdateProduct(id, product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        [HttpGet("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
