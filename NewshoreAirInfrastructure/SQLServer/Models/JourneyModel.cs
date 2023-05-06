using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Models
{
    public class JourneyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JourneyId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }

        public virtual ICollection<JourneyFlightModel> Flights { get; set; }
    }
}
