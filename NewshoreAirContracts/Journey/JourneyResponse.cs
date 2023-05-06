using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirContracts.Journey
{
    public record JourneyResponse(
        string Origin,
        string Destination,
        float Price,
        List<FlightResponse> Flights
        );

    public record FlightResponse(
        string Origin,
        string Destination,
        float Price,
        TransportResponse Transport
        );

    public record TransportResponse (
        string FlightCarrier,
        string FlightNumber
        );
}
