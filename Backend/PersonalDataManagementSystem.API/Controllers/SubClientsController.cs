using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PersonalDataManagementSystem.Application.DTOs.SubClients;
using PersonalDataManagementSystem.Application.UseCases.Commands.SubClients;
using PersonalDataManagementSystem.Application.UseCases.Queries.SubClients;

namespace PersonalDataManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubClientsController : ControllerBase
    {

        private readonly CreateSubClient _create;
        private readonly DeleteSubClient _delete;
        private readonly UpdateSubClient _update;
        private readonly GetSubClients _clients;
        private readonly GetSubClientById _clientById;
        private readonly IMemoryCache _memoryCache;

        public SubClientsController(CreateSubClient create, DeleteSubClient delete, UpdateSubClient update, GetSubClients clients, GetSubClientById clientById, IMemoryCache memoryCache)
        {
            _clientById = clientById;
            _clients = clients;
            _create = create;
            _delete = delete;
            _update = update;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubClient([FromBody] SubClientCreateDTO client)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_memoryCache.TryGetValue("SubClients", out _))
            {
                _memoryCache.Remove("SubClients");
            }

            return Ok(await _create.ExecuteAsync(client));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubClient([FromRoute] Guid id)
        {
            if (_memoryCache.TryGetValue("SubClients", out _))
            {
                _memoryCache.Remove("SubClients");
            }

            await _delete.ExecuteAsync(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubClientById([FromRoute] Guid id)
        {
            var result = await _clientById.ExecuteAsync(id);

            if (result == null) return NotFound($"The SubClient with Id {id} can not be found");

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubClients()
        {
            if (!_memoryCache.TryGetValue("SubClients", out List<SubClientDTO>? cachedItems))
            {
                var items = await _clients.ExecuteAsync();

                _memoryCache.Set("SubClients", items, new MemoryCacheEntryOptions
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
        public async Task<IActionResult> UpdateSubClient([FromBody] SubClientUpdateDTO client)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.ToString());

            if (_memoryCache.TryGetValue("SubClients", out _))
            {
                _memoryCache.Remove("SubClients");
            }

            return Ok(await _update.ExecuteAsync(client));
        }
    }
}
