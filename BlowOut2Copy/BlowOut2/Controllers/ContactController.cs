using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut2.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public String Index()
        {
            return "Please call Support at <strong><u>801-555-1212</u></strong>";
        }

        public String Email(String name, String email)
        {
            return "Thank you " + name + ". We are sending an email to " + email + ".com";
        }
    }
}