using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut2.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        public int instrumentID { get; set; }
        public String instrumentName { get; set; }
        public String condition { get; set; }
        public decimal price { get; set; }
        public String imgPath { get; set; }
        public int? clientID { get; set; }
    }
}