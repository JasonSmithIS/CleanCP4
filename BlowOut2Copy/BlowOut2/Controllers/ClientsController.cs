using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlowOut2.DAL;
using BlowOut2.Models;

namespace BlowOut2.Controllers
{
    public class ClientsController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        //Summary Action Method, which accepts the ClientID, and Instrument ID from the Client Create View
        public ActionResult Summary(int? ClientID, int? InstrumentID)
        {
            //Looks up the Client by the ClientID that was passed in
            Client client = db.Clients.Find(ClientID);
            //Looks up the Instrument by the InstrumentID that was passed in
            Instrument Instrument = db.Instruments.Find(InstrumentID);
            //Creates Viewbag objects from the Client Object found
            ViewBag.Client = client;
            //Creates a Viewbag object from the Instrument object found
            ViewBag.Instrument = Instrument;
            return View(client);
        }
        // GET: Clients/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult Create(int? InstrumentID)
        {
            //Looks up the Instrument by the InstrumentID that was passed in
            Instrument Instrument = db.Instruments.Find(InstrumentID);
            //Creates a Viewbag object from the Instrument object found
            ViewBag.Instrument = Instrument;
            return View();
        }
        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,clientLastName,clientFirstName,clientPhoneNum,clientEmail,address,city,state,zip")] Client client, int? InstrumentID)
        {
            if (ModelState.IsValid)
            {
                //Adds the new client to the database
                db.Clients.Add(client);
                //Saves the changes to the Database
                db.SaveChanges();
                //Looks up the Instrument in the Database
                Instrument Instrument = db.Instruments.Find(InstrumentID);
                //Sets the value for the clientID in the Instruments table to assign a borrower
                Instrument.clientID = client.clientID;
                //Saves changes to the Instruments DB
                db.SaveChanges();
                //Sends the user to the transaction summary page, and passes in the Client, and Instrument ID's
                return RedirectToAction("Summary", new {ClientID = client.clientID, InstrumentID = Instrument.instrumentID });
            }
            Instrument oInstrument = db.Instruments.Find(InstrumentID);
            ViewBag.Instrument = oInstrument;
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,clientLastName,clientFirstName,clientPhoneNum,clientEmail,address,city,state,zip")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateData");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            db.Database.ExecuteSqlCommand("Update Instrument set Instrument.clientID = null where Instrument.clientID =" + id);
            return RedirectToAction("UpdateData");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult UpdateData()
        {
            IEnumerable<Rental> rental = db.Database.SqlQuery<Rental>("Select Client.clientID, clientLastName, clientFirstName, clientPhoneNum, clientEmail, address, city, state, zip, instrumentID, instrumentName, condition, price, imgPath from Client, Instrument where Instrument.clientID = Client.clientID");

            return View(rental);
        }
    }
}
