using Exercise_05.Data;
using Exercise_05.Models;
using Exercise_05.Models.Dtos;
using Exercise_05.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Exercise_05.Services
{
    public interface ITripsService
    {
        Task<Trip?> GetTrip(int IdTrip);
        Task<IEnumerable<TripDto>> GetTrips();
    }

    public class TripsService : ITripsService
    {
        private readonly ApbdContext _context;

        public TripsService(ApbdContext context)
        {
            _context = context;
        }

        public async Task<Trip?> GetTrip(int IdTrip)
        {
            return await _context.Trips.FirstOrDefaultAsync(trip => trip.IdTrip == IdTrip);
        }

        public async Task<IEnumerable<TripDto>> GetTrips()
        {
            return await _context.Trips.Select(trip => new TripDto
            {
                Name = trip.Name,
                Description = trip.Description,
                DateFrom = trip.DateFrom,
                DateTo = trip.DateTo,
                MaxPeople = trip.MaxPeople,
                Countries = trip.IdCountries.Select(country => new CountryDto 
                    { 
                        Name = country.Name 
                    }
                ),
                Clients = trip.ClientTrips.Select(clientTrip => new ClientDto 
                    {
                        FirstName = clientTrip.IdClientNavigation.FirstName,
                        LastName = clientTrip.IdClientNavigation.LastName
                    }
                )
            })
                .OrderByDescending(trip => trip.DateFrom)
                .ToArrayAsync();
        }
    }
}
