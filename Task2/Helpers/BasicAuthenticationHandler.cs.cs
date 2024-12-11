using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Primitives;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authorizationHeader = Request.Headers["Authorization"];

        if (StringValues.IsNullOrEmpty(authorizationHeader))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        var authHeaderValue = authorizationHeader[0]; 

        if (!authHeaderValue.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        var base64Credentials = authHeaderValue.Substring("Basic ".Length).Trim();
        string[] credentials;

        try
        {
            credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64Credentials)).Split(':');
        }
        catch (FormatException)
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header format"));
        }

        if (credentials.Length != 2)
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
        }

        var username = credentials[0];
        var password = credentials[1];

        if (username == "admin" && password == "admin") 
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, "Basic");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Basic");

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

        return Task.FromResult(AuthenticateResult.Fail("Invalid username or password"));
    }
}
