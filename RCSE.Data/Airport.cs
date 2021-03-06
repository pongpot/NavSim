﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE.Data
{
    public class Airport
    {
        public List<Runway> Runway { get; set; }
        public List<Navaid> Navaid { get; set; }
        public Airport()
        {
            Runway = new List<Runway>();
            Navaid = new List<Navaid>();
        }
        public Airport(List<Runway> runway, List<Navaid> navaid)
        {
            Runway = new List<Runway>(runway);
            Navaid = new List<Navaid>(navaid);
        }
    }
}
