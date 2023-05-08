using NewshoreAirDomain.Journey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirApplication.Interfaces.Persistance
{
    /// <summary>
    /// IJourneyRespository is the contract that should implement the data
    /// repository where the flight data will be hosted.
    /// </summary>
    public interface IJourneyRespository
    {
        /// <summary>
        /// GetJourneys receives the origin and destination of a flight to get the flights from the
        /// data repository that match the given origin and destination.
        /// </summary>
        /// <param name="origin">Journey origin</param>
        /// <param name="destination">Journey destination</param>
        /// <returns>
        /// The journey with matching the given origin and destination.
        /// </returns>
        Journey GetJourneys(string origin, string destination);

        /// <summary>
        /// CreateJourney create a new trip in the data repository so that it can be queried later on 
        /// </summary>
        /// <param name="journey">New journey</param>
        void CreateJourney(Journey journey);
    }
}
