using NewshoreAirDomain.Journey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirApplication.Journeys
{
    public interface IJourneyHandler
    {
        Task<Journey> GetJourney(string origin, string destination);
    }
}
