﻿using JALKAHOITLOA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JALKAHOITLOA.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index1()
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<Product> model = entities.Products.ToList();
            entities.Dispose();

            return View(model);
        }
        public ActionResult GetProducts(string id)
        {
            int idi;
            idi = 2;
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<Product> products = (from o in entities.Products
                                      where o.GroupId == idi
                                      select o).ToList();

            return View(products);
        }
    }
}