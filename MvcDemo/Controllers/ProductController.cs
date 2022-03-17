using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcDemo.DAL.Context;
using MvcDemo.DAL.Entities;

namespace MvcDemo.Controllers
{
    public class ProductController : Controller
    {
        private DemoContext c = new DemoContext();
        public IActionResult Index()
        {
            var values = c.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteProduct(int id)
        {
            var value = c.Products.Find(id);
            c.Products.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var value = c.Products.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            var value = c.Products.Find(p.ProductID);
            value.ProductName = p.ProductName;
            value.Stock = p.Stock;
            value.Price = p.Price;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
