using JALKAHOITLOA.Models;
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
        public ActionResult Index()
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<Product> model = entities.Products.ToList();
            entities.Dispose();

            return View(model);
        }
    }
}