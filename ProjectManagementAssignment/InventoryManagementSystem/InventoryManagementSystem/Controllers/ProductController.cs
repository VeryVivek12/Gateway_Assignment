using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        InventoryMgtEntities db = new InventoryMgtEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x => x.ID).ToList();
            return View(list);

        }

     


        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<string> list = db.Products.Select(x => x.Category).ToList();
            ViewBag.Category = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product pr = db.Products.Where(x => x.ID == id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, Product product)
        {
            Product pr = db.Products.Where(x => x.ID == id).SingleOrDefault();
            pr.Name = product.Name;
            pr.Category = product.Category;
            pr.Price = product.Price;
            pr.Quantity = product.Quantity;
            pr.SDesc = product.SDesc;
            pr.LDesc = product.LDesc;
            pr.SImg = product.SImg;
            pr.LImg = product.LImg;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            Product product = db.Products.Where(x => x.ID == id).SingleOrDefault();

            return View(product);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Where(x => x.ID == id).SingleOrDefault();

            return View(product);

        }

        [HttpPost]
        public ActionResult DeleteProduct(int id, Product product)
        {

            db.Products.Remove(db.Products.Where(x => x.ID == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}