using Microsoft.EntityFrameworkCore;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Infrastructure.Persistance.Repositories.BusinessObjects;

internal class ClientsRepository : IClientsRepository
{
    private readonly SystemDbContext _context;

    public ClientsRepository(SystemDbContext context)
    {
        _context = context;
    }

    public async Task<Client> CreateClientAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task DeleteClientAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
        }
    }

    public async Task<Client?> GetClientByIdAsync(Guid id)
    {
        return await _context.Clients
            .AsNoTracking()
            .Include(c => c.SubClients)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await _context.Clients.AsNoTracking().ToListAsync();
    }

    public async Task<Client> UpdateClientAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();

        return client;
    }
}
