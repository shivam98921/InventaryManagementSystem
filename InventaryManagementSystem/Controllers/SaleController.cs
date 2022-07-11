using InventaryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InventaryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managementEntities11 db = new Inventory_managementEntities11();        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale S)
        {
            db.Sales.Add(S);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(int id, Sale S)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            s.Sale_prod = S.Sale_prod;
            s.Sale_qnty = S.Sale_qnty;
            s.Sale_date = S.Sale_date;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();

            return View(s);
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            //List<string> list = db.Products.Select(x => x.Product_name).ToList();
            //ViewBag.ProductName = new SelectList(list);
            return View(s);
        }

        [HttpPost]
        public ActionResult Delete(int id, Sale S)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            db.Sales.Remove(s);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");

        }
    }
}