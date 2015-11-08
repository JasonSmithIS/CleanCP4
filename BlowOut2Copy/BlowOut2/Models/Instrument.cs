using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut2.Models
{
    //References the Database Table, must match
    [Table("Instrument")]
    public class Instrument
    {
        //The automatically generated/ Incremented Primary key for the Database -- Not null
        [Key]
        public int instrumentID { get; set; }
        //The name of the Instrument -- Not null
        public String instrumentName { get; set; }
        //The New or Used condition -- Not null
        public String condition { get; set; }
        //The monthly rental price -- Not null
        public decimal price { get; set; }
        //The file path the retrieve the Image -- Not null
        public String imgPath { get; set; }
        //The ? allows the feild to be null in the model
        public int? clientID { get; set; }
    }
}