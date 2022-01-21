using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var value = db.TBLPRODUCTS.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> value = (from i in db.TBLCATEGORIES.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.CategoryId.ToString()
                                          }).ToList();
            ViewBag.val = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(TBLPRODUCTS p1)
        {
            var ctg = db.TBLCATEGORIES.Where(m => m.CategoryId == p1.TBLCATEGORIES.CategoryId).FirstOrDefault();
            p1.TBLCATEGORIES = ctg;
            db.TBLPRODUCTS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = db.TBLPRODUCTS.Find(id);
            db.TBLPRODUCTS.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringProduct(int id)
        {
            var product = db.TBLPRODUCTS.Find(id);

            List<SelectListItem> value = (from i in db.TBLCATEGORIES.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.CategoryId.ToString()
                                          }).ToList();
            ViewBag.val = value;
            return View("BringProduct", product);
        }
        public ActionResult Update(TBLPRODUCTS p)
        {
            var product = db.TBLPRODUCTS.Find(p.ProductId);
            product.ProductName = p.ProductName;
            product.Price = p.Price;
            product.Brand = p.Brand;
            product.Stock = p.Stock;
            //product.ProductCategory = p.ProductCategory;
            var ctg = db.TBLCATEGORIES.Where(m => m.CategoryId == p.TBLCATEGORIES.CategoryId).FirstOrDefault();
            product.ProductCategory = ctg.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}