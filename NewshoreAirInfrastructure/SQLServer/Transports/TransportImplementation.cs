using Microsoft.Identity.Client;
using NewshoreAirDomain.Errors;
using NewshoreAirDomain.Journey.Entities;
using NewshoreAirInfrastructure.SQLServer.Mapper;
using NewshoreAirInfrastructure.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Transports
{
    public class TransportImplementation
    {
        public Transport getTransportById(int transportId)
        {
            try
            {
                using (NewshoreAirContext db = new NewshoreAirContext())
                {
                    var record = db.Transports.Where(t => t.TransportId == transportId).FirstOrDefault();
                    if (record == null) 
                    {
                        throw new CustomError("Dont exist Transport in the database.", null);
                    }
                    TransportMapper mapper = new TransportMapper();
                    return mapper.MapperT1T2(record);
                }
            }
            catch (Exception ex)
            {
                throw new CustomError(
                    "Something happened while trying to get a Transport in the database.",
                    ex);
            }
        }

        public void CreateTransport(Transport transport)
        {
            using (NewshoreAirContext db = new NewshoreAirContext())
            {
                try
                {
                    TransportMapper mapper = new TransportMapper();
                    TransportModel record = mapper.MapperT2T1(transport);
                    db.Add(record);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new CustomError(
                        "Something happened while trying to create a Transport in the database.",
                        ex);
                }
            }
        }
    }
}
