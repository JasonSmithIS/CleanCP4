﻿using BlowOut2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlowOut2.DAL
{
    public class BlowOutContext :DbContext
    {
        public BlowOutContext() :base("BlowOutContext")
        {

        }
        //Defines the two DB tables as object classes
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}