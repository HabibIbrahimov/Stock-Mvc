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
            db.TBLPRODUCTS.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}