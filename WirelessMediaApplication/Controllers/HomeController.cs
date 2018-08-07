using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WirelessMediaApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PocetnaStrana()
        {
            ViewBag.Title = "Pocetna Strana";

            return View();
        }
        public ActionResult IzmenaProizvoda(int? id)
        {
            ViewBag.Title = "Izmena proizvoda";
            ViewBag.IdProizvoda = id.Value;
            return View();

        }
        public ActionResult UnosNovogProizvoda()
        {

            return View();

        }
    }
}
