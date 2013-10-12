using Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryWeb.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            ViewBag.Products = Product.GetProducts();
            return View();
        }

        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection post) {
            try {
                // Aqui se agregan las cuentas
                Product product = Product.CreateProduct(post["productName"].ToString());
                TempData["msg"] = "<div class='alert alert-success'>¡Producto creado!</div>";
                return RedirectToAction("Index");
            }
            catch (Exception e) {
                TempData["msg"] = "<div class='alert alert-danger'>" + e.Message.ToString() + "</div>";
                return RedirectToAction("Create");
            }
        }

    }
}
