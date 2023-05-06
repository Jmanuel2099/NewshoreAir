using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Models
{
    public class TransportModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportId { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set;}

        public virtual ICollection<FlightModel> Flights { get; set;}
    }
}
