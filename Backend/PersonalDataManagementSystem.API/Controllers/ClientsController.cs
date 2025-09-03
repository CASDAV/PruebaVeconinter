using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PersonalDataManagementSystem.Application.DTOs.Clients;
using PersonalDataManagementSystem.Application.UseCases.Commands.Clients;
using PersonalDataManagementSystem.Application.UseCases.Queries.Clients;

namespace PersonalDataManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly CreateClient _create;
        private readonly DeleteClient _delete;
        private readonly UpdateClient _update;
        private readonly GetClients _clients;
        private readonly GetClientById _clientById;
        private readonly IMemoryCache _memoryCache;

        public ClientsController(CreateClient create, DeleteClient delete, UpdateClient update, GetClients clients, GetClientById clientById, IMemoryCache memoryCache)
        {
            _clientById = clientById;
            _clients = clients;
            _create = create;
            _delete = delete;
            _update = update;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientCreateDTO client)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_memoryCache.TryGetValue("Clients", out _))
            {
                _memoryCache.Remove("Clients");
            }

            return Ok(await _create.ExecuteAsync(client));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
        {
            if (_memoryCache.TryGetValue("Clients", out _))
            {
                _memoryCache.Remove("Clients");
            }

            await _delete.ExecuteAsync(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById([FromRoute] Guid id)
        {
            var result = await _clientById.ExecuteAsync(id);

            if (result == null) return NotFound($"The Client with Id {id} can not be found");

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            if (!_memoryCache.TryGetValue("Clients", out List<ClientDTO>? cachedItems))
            {
                var items = await _clients.ExecuteAsync();

                _memoryCache.Set("Clients", items, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                    SlidingExpiration = TimeSpan.FromMinutes(5),
                    Size = 1
                });

                return Ok(items);
            }
            else
            {
                return Ok(cachedItems);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] ClientUpdateDTO client)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.ToString());

            if (_memoryCache.TryGetValue("Clients", out _))
            {
                _memoryCache.Remove("Clients");
            }

            return Ok(await _update.ExecuteAsync(client));
        }
    }
}
