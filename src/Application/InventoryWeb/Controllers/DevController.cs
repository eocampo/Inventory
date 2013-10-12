using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryWeb.Controllers
{
    public class DevController : Controller
    {
        //
        // GET: /Dev/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateSchema() {
            Inventory.Data.DatabaseManager.CreateSchema();
            return new RedirectResult("~/dev/");
        }

        public ActionResult DropSchema() {
            Inventory.Data.DatabaseManager.DropSchema();
            return new RedirectResult("~/dev/");
        }

    }
}
