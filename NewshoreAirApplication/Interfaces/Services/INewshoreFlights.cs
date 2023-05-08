using NewshoreAirDomain.Journey;
using NewshoreAirDomain.Journey.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirApplication.Interfaces.Services
{
    /// <summary>
    /// INewshoreFlights is the contract that should implement the
    /// service where the flights available in newshore are obtained.
    /// </summary>
    public interface INewshoreFlights
    {
        /// <summary>
        /// GetNewshoreFlights gets the flights that are hosted in the newshoreAir
        /// server to use them in the trips. 
        /// </summary>
        /// <returns>The list of available flights</returns>
        Task<IEnumerable<Flight>> GetNewshoreFlights();
    }
}
