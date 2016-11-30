using JALKAHOITLOA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JALKAHOITLOA.Models
{
    public class ProductGroupsController : Controller
    {
        // GET: ProductGroups
        public ActionResult Index()
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<ProductGroup> model = entities.ProductGroups.ToList();
            entities.Dispose();

            return View(model);
            
        }
    }
}