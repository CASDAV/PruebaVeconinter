using Microsoft.Kiota.Abstractions.Authentication;

namespace PersonalDataManagementSystem.Front.Helpers;

public class SessionAccessTokenProvider : IAccessTokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionAccessTokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public AllowedHostsValidator AllowedHostsValidator => new AllowedHostsValidator();

    public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default, CancellationToken cancellationToken = default)
    {
        var token = _httpContextAccessor.HttpContext?.Session.GetString("AccessToken");
        return Task.FromResult(token ?? "");
    }
}
