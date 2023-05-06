using NewshoreAirApplication.Interfaces.Persistance;
using NewshoreAirDomain.Errors;
using NewshoreAirDomain.Journey;
using NewshoreAirInfrastructure.SQLServer.Mapper;
using NewshoreAirInfrastructure.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Journeys
{
    public class JourneyImplementation : IJourneyRespository
    {
        public void CreateJourney(Journey journey)
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try
                {
                    Console.WriteLine("Hola llegue a intentar guardar en la db");
                    JourneyMapper mapper = new JourneyMapper();
                    JourneyModel record = mapper.MapperT2T1(journey);
                    db.Journeys.Add(record);
                }
                catch (Exception ex)
                {

                    throw new CustomError(
                        "Something happened while trying to create a journey in the database.",
                        ex);
                }
            }
        }

        public IEnumerable<Journey> GetJourneys(string origin, string destination)
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try 
                {
                    Console.WriteLine("Hola llegue a intentar buscar en la db ");
                    var record = db.Journeys
                    .Where(x => x.Destination == destination && x.Origin == origin)
                    .ToList();
                    if (record != null)
                    {
                        return Enumerable.Empty<Journey>();
                    }
                    JourneyMapper journeyMapper = new JourneyMapper();

                    return journeyMapper.MapperT1T2(record); ;
                } 
                catch (Exception ex) 
                {
                    throw new CustomError(
                        "Something happened while trying to search for the journey in the database.",
                        ex);
                }
                
            }
        }
    }
}
