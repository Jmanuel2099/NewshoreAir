using NewshoreAirDomain.Journey;
using NewshoreAirDomain.Journey.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirApplication.Interfaces.Services
{
    public interface INewshoreFlights
    {
        Task<IEnumerable<Flight>> GetNewshoreFlights();
    }
}
