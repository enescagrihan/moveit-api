using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Text;
using MoveIt.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MoveIt.Data;

namespace MoveIt.Handler

{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AppDbContext _appDbContext;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> option, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock, AppDbContext dBContext) : base(option, logger, encoder, clock)
        {
            _appDbContext = dBContext;
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No header found");

            var _headervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(_headervalue.Parameter != null ? _headervalue.Parameter : string.Empty);
            string credentials = Encoding.UTF8.GetString(bytes);
            if (!string.IsNullOrEmpty(credentials))
            {
                string[] array = credentials.Split(":");
                string email = array[0];
                string password = array[1];
                var user = await this._appDbContext.Users.FirstOrDefaultAsync(item => item.EMail == email && item.Password == password);
                Console.WriteLine(user);
                if (user == null)
                    return AuthenticateResult.Fail("UnAuthorized");

                // Generate Ticket
                var claim = new[] { new Claim(ClaimTypes.Name, email) };
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("UnAuthorized");

            }
        }
    }
}