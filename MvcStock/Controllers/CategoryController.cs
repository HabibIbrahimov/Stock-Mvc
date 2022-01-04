﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var value = db.TBLCATEGORIES.ToList();
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
            db.TBLCATEGORIES.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}