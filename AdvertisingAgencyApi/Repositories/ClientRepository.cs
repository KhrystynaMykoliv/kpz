using Microsoft.EntityFrameworkCore;
using AdvertisingAgencyApi.Models;

namespace AdvertisingAgencyApi.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly AdvertisingAgencyContext _context;

        public ClientRepository(AdvertisingAgencyContext context) : base(context) 
        {
            _context = context;
        }

        public new async Task AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public new async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients
                .Include(c => c.Person)
                .ToListAsync();
        }

        public new async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.PersonId == id);
        }

        public async Task UpdateAsync(Client client)
        {
            var existingClient = await _context.Clients
                .Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.PersonId == client.PersonId);

            if (existingClient == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            existingClient.CompanyName = client.CompanyName;
            if (existingClient.Person != null && client.Person != null)
            {
                existingClient.Person.FirstName = client.Person.FirstName;
                existingClient.Person.LastName = client.Person.LastName;
                if (existingClient.Person.Email != client.Person.Email)
                {
                    existingClient.Person.Email = client.Person.Email;
                }
                existingClient.Person.Phone = client.Person.Phone;
            }

            _context.Clients.Update(existingClient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.PersonId == id);

            if (client == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
