using AspNetCoreApp.Web.Helpers;
using AspNetCoreApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace AspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private IHelper _helper;
        private readonly ProductRepository _productRepository;

        public ProductController(AppDbContext context, IHelper helper)
        {
            _productRepository = new ProductRepository();
            _context = context;
            _helper = helper;
        }

        public IActionResult Index()
        {
            var text = "Asp.Net Core";
            var upperText = _helper.Upper(text);

            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["status"] = "Ürün Eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product, int productId, string type)
        {
            product.Id = productId;
            _context.Products.Update(product);
            _context.SaveChanges();

            TempData["status"] = "Ürün Güncellendi.";
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
