using Exercise_05.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_05.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpDelete("{IdClient:int}")]
        public async Task<IActionResult> DeleteClient(int IdClient)
        {
            var client = await _clientService.GetClient(IdClient);
            
            if(client is null) 
            {
                return NotFound();
            }

            var clientTrips = await _clientService.GetClientTrips(IdClient);

            if(clientTrips.Any())
            {
                return Conflict();
            }

            return NoContent();
        }
    }
}
