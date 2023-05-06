using NewshoreAirDomain.Journey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirApplication.Interfaces.Persistance
{
    public interface IJourneyRespository
    {
        IEnumerable<Journey> GetJourneys(string origin, string destination);
        
        void CreateJourney(Journey journey);
    }
}
