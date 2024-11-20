using Microsoft.EntityFrameworkCore;
using AdvertisingAgencyApi.Models;

namespace AdvertisingAgencyApi.Repositories
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        private readonly AdvertisingAgencyContext _context;

        public ContractRepository(AdvertisingAgencyContext context) : base(context) 
        {
            _context = context;
        }

        public new async Task AddAsync(Contract Contract)
        {
            _context.Contracts.Add(Contract);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contract>> GetAllAsync()
        {
            return await _context.Contracts
                .Include(c => c.Manager)
                    .ThenInclude(m => m.Person)
                .Include(c => c.Client)
                .ToListAsync();
        }

        public async Task<Contract?> GetByIdAsync(int id)
        {
            return await _context.Contracts
                .Include(c => c.Manager)
                    .ThenInclude(m => m.Person)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(c => c.ContractCode == id);
        }

        public new async Task UpdateAsync(Contract Contract)
        {
            _context.Contracts.Update(Contract);
            await _context.SaveChangesAsync();
        }
    }
}
