using System.Net.Sockets;
using Exercise_05.Data;
using Exercise_05.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_05.Services
{
    public interface IClientService 
    {
        Task<Client?> GetClient(int IdClient);
        Task<Client?> GetClientByPesel(string pesel);
        Task<IEnumerable<ClientTrip>> GetClientTrips(int IdClient);
        Task DeleteClient(int IdClient);
    }
    public class ClientService : IClientService
    {
        private readonly ApbdContext _context;

        public ClientService(ApbdContext context)
        {
            _context = context;
        }

        public async Task<Client?> GetClient(int IdClient)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.IdClient == IdClient);
        }

        public async Task<Client?> GetClientByPesel(string pesel)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.Pesel == pesel);
        }

        public async Task<IEnumerable<ClientTrip>> GetClientTrips(int IdClient)
        {
            return await _context.ClientTrips.Where(clientTrip => clientTrip.IdClient == IdClient).ToListAsync();
        }

        public async Task DeleteClient(int IdClient)
        {
            var client =  await GetClient(IdClient) ?? throw new InvalidOperationException();

            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
}
