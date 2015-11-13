using BlowOut2.DAL;
using BlowOut2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut2.Controllers
{
    public class HomeController : Controller
    {
        //Adds the Database Context as a variable in this controller.
        private BlowOutContext db = new BlowOutContext();
        //Returns the Home Index View or Landing Page.
        public ActionResult Index()
        {
            return View();
        }
        //Returns the Home About View
        public ActionResult About()
        {
            return View();
        }
        //Returns the Home Contact View
        public ActionResult Contact()
        {
            ViewBag.Message = "BlowOut Instrument Rentals contact page.";

            return View();
        }
        //Returns the Home Rentals View, and passes the Instrument database objects as a list to be displayed
        public ActionResult Rentals()
        {
            return View(db.Instruments.ToList());
        }
        //Returns the Individual Item Rental View -- Not in use in Checkpoint 4 --
        public ActionResult RentalItem()
        {

            return View();
        }
        
    }
}