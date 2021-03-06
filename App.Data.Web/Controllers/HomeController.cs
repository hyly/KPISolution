﻿using App.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Data.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices productSvc = null;
        public HomeController(IProductServices productServices)
        {
            this.productSvc = productServices;
        }
        public ActionResult Index()
        {
            var product = productSvc.GetProductById(1);
            ViewBag.product = product;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}