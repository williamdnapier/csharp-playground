using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _027_WebAppMvcRazor.Models;

namespace _027_WebAppMvcRazor.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };

        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }

        public ViewContext MyViewContext()
        {
            return new ViewContext();
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            Product[] array =
            {
                new Product { },
                new Product { },
                new Product { },
                new Product { }
            };

            return View(array);
        }
    }

    //Discussion
    //In a good MVC Framework application, there is a clear separation
    //between the roles that the action method and view perform. The
    //rules are simple:

    //ActionMethod
    //It passes a view model object to the view.
    //It does NOT pass formatted data to the view.

    //View
    //It uses the view model object to present content to the user.
    //It does NOT change any aspect of the view model object.
}