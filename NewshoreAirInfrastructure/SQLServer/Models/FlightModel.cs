﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Models
{
    public class FlightModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }
        public int TransportId { get; set; }

        [ForeignKey("TransportId")]
        public virtual TransportModel Transport { get; set; }

        public virtual ICollection<JourneyFlightModel> Flights { get; set; }
    }
}
