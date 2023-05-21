using Exercise_05.Models.Dtos;
using Exercise_05.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_05.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;
        private readonly IClientService _clientService;

        public TripsController(ITripsService tripsService, IClientService clientService)
        {
            _tripsService = tripsService;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            return Ok(await _tripsService.GetTrips());
        }

        [HttpPost]
        [Route("{IdTrip:int}/clients")]
        public async Task<IActionResult> PostTripClient(int IdTrip, [FromBody] TripClientPostDto tripClientPostDto)
        {
            var client = await _clientService.GetClientByPesel(tripClientPostDto.Pesel);
            var trip = await _tripsService.GetTrip(IdTrip);

            if(trip is null) {
                return NotFound();
            }

            if(client is null)
            {
                // Save user to database
            }

            return Ok();
        }
    }
}
