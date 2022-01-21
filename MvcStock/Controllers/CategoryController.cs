using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index(int page=1)
        {
            //var value = db.TBLCATEGORIES.ToList();
            var value = db.TBLCATEGORIES.ToList().ToPagedList(page,2 );
            return View(value);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(TBLCATEGORIES p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TBLCATEGORIES.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var category = db.TBLCATEGORIES.Find(id);
            db.TBLCATEGORIES.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringCategory(int id)
        {
            var ctgr = db.TBLCATEGORIES.Find(id);
            return View("BringCategory", ctgr);
        }
        public ActionResult Update(TBLCATEGORIES p1)
        {
            var ctgr = db.TBLCATEGORIES.Find(p1.CategoryId);
            ctgr.CategoryName = p1.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}