using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut2.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int clientID { get; set; }
        public String clientLastName { get; set; }
        public String clientFirstName { get; set; }
        public String clientPhoneNum { get; set; }
        public String clientEmail { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        public String State { get; set; }
        public String zip { get; set; }
    }
}