﻿using Microsoft.AspNetCore.Mvc;
using NewshoreAirAPI.Mapper;
using NewshoreAirAPI.Models.Request;
using NewshoreAirAPI.Models.Response.JourneyResponse;
using NewshoreAirApplication.Journeys;
using NewshoreAirDomain.Journey;


namespace NewshoreAirAPI.Controllers
{
    [Route("joruney")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private IJourneyHandler _journeyHandler;

        public JourneyController(IJourneyHandler journeyHandler)
        {
            _journeyHandler = journeyHandler;
           
        }

        [HttpGet("calculate")]
        public async Task<IActionResult> CalculateJourney(string origin, string destination)
        {
            try
            {
                if (origin.Length > 3)
                {
                    return BadRequest("The origin must have only three characters,(COL, MEX).");
                }

                if (destination.Length > 3)
                {
                    return BadRequest("The destination must have only three characters,(COL, MEX).");
                }

                Journey journey = await _journeyHandler.GetJourney(
                    origin.ToUpper(),
                    destination.ToUpper());

                if (!journey.Flights.Any())
                {
                    return new ContentResult
                    {
                        StatusCode = 204,
                        Content = "It is not possible to calculate a route."


                    };
                }
                JourneyMapper journeyMapper = new JourneyMapper();
                JourneyResponse journeyResponse = journeyMapper.MapperT1T2(journey);

                return Ok(journeyResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

    }
}