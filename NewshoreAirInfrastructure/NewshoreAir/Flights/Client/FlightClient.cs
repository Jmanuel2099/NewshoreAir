using NewshoreAirApplication.Interfaces.Services;
using NewshoreAirDomain.Journey.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NewshoreAirInfrastructure.NewshoreAir.Mapper;

namespace NewshoreAirInfrastructure.NewshoreAir.Flights.Client
{
    public class FlightClient : INewshoreFlights
    {
        public async Task<IEnumerable<Flight>> GetNewshoreFlights()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://recruiting-api.newshore.es/api/flights/1");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var flightResponse = JsonConvert
                        .DeserializeObject<List<FlightResponse>>(content);

                    FlightMapper flightMapper = new FlightMapper();

                    return flightMapper.MapperT1T2(flightResponse);
                }
                else
                {
                    throw new HttpRequestException($"Error getting flights: {response.StatusCode}");
                }
            }
        }
    }
}
