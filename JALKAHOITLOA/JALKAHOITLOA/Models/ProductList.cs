using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JALKAHOITLOA.Models
{
    public class ProductList
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public int UnitOfMeasure { get; set; }
        public int GroupId { get; set; }
    }
}