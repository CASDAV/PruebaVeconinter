using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalDataManagementSystem.BackendClient;
using PersonalDataManagementSystem.BackendClient.Models;

namespace PersonalDataManagementSystem.Front.Models;

[Authorize]
public class ClientsModel : PageModel
{
    public List<ClientDTO> BussinessClients { get; set; }
    private readonly ApiClient _apiClient;

    public ClientsModel(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task OnGet()
    {
        BussinessClients = await _apiClient.Api.Clients.GetAsync();
    }

}
