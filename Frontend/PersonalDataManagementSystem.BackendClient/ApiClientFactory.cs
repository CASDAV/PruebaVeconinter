using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace PersonalDataManagementSystem.BackendClient;

public class ApiClientFactory
{
    private readonly HttpClient _http;
    private readonly IAuthenticationProvider _auth;

    public ApiClientFactory(HttpClient http, IAccessTokenProvider tokenProvider)
    {
        _http = http;
        _auth = new BaseBearerTokenAuthenticationProvider(tokenProvider);
    }

    public ApiClient GetClient()
    {
        var adapter = new HttpClientRequestAdapter(_auth, httpClient: _http);
        var client = new ApiClient(adapter);

        return client;
    }
}
