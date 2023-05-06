using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Models
{
    public class JourneyFlightModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JourneyFlightId { get; set; }
        public int JourneyId { get; set; }
        public int FlightId { get; set; }

        [ForeignKey("JourneyId")]
        public JourneyModel Journey { get; set; }
        [ForeignKey("FlightId")]
        public FlightModel Flight { get; set; }
    }
}
