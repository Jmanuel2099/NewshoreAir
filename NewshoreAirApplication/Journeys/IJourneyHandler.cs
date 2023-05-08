using NewshoreAirDomain.Journey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirApplication.Journeys
{
    /// <summary>
    /// IJourneyHandler is the contract to be implemented in the infrastructure
    /// layer to facilitate the injection of the dependency in the layer that needs it.
    /// </summary>
    public interface IJourneyHandler
    {
        /// <summary>
        /// GetJourney retrieves the origin and destination of the trip to
        /// calculate if it is possible to make the trip and deliver the flights
        /// that are necessary to make the trip.
        /// </summary>
        /// <param name="origin">journey origin</param>
        /// <param name="destination">destination journey</param>
        /// <returns>
        /// the journey with the flights it has that are necessary to perform the journey.
        /// </returns>
        Task<Journey> GetJourney(string origin, string destination);
    }
}
