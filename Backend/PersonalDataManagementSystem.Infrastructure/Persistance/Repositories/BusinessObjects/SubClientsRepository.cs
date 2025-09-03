using Microsoft.EntityFrameworkCore;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Infrastructure.Persistance.Repositories.BusinessObjects;

internal class SubClientsRepository : ISubClientsRepository
{
    private readonly SystemDbContext _context;

    public SubClientsRepository(SystemDbContext context)
    {
        _context = context;
    }

    public async Task<SubClient> CreateSubClientAsync(SubClient subClient)
    {
        await _context.SubClients.AddAsync(subClient);
        await _context.SaveChangesAsync();

        return subClient;
    }

    public async Task DeleteSubClientAsync(Guid id)
    {
        var subClient = await _context.SubClients.FindAsync(id);
        if (subClient != null)
        {
            _context.SubClients.Remove(subClient);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<SubClient?> GetSubClientByIdAsync(Guid id)
    {
        return await _context.SubClients
            .AsNoTracking()
            .FirstOrDefaultAsync(sc => sc.Id == id);
    }

    public async Task<IEnumerable<SubClient>> GetSubClientsAsync()
    {
        return await _context.SubClients
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<SubClient> UpdateSubClientAsync(SubClient subClient)
    {
        _context.SubClients.Update(subClient);
        await _context.SaveChangesAsync();

        return subClient;
    }
}
