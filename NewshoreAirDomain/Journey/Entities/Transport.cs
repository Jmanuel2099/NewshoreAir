﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Journey.Entities
{
    public class Transport
    {
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }

        public Transport (string FlightCarrier, string FlightNumber)
        {
            this.FlightCarrier = FlightCarrier;
            this.FlightNumber = FlightNumber;
        }

        
    }
}