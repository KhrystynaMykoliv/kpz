using Microsoft.EntityFrameworkCore;
using AdvertisingAgencyApi.Models;

namespace AdvertisingAgencyApi.Repositories
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        private readonly AdvertisingAgencyContext _context;

        public ManagerRepository(AdvertisingAgencyContext context) : base(context) 
        {
            _context = context;
        }

        public new async Task AddAsync(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
        }

        public new async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.Managers
                .Include(c => c.Person)
                .ToListAsync();
        }

        public new async Task<Manager?> GetByIdAsync(int id)
        {
            return await _context.Managers
                .Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.PersonId == id);
        }
    }
}
