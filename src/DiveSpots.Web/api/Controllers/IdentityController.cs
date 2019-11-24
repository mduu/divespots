using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DiveSpots.Web.Core.TokenHandling;
using JetBrains.Annotations;

namespace DiveSpots.Web.api.Controllers
{
    [Route("api/v1/identity")]
    public class IdentityController : Controller
    {
        private readonly ILogger logger;
        private readonly ITokenGenerator tokenGenerator;

        public IdentityController(
            [NotNull] ILogger<IdentityController> logger,
            [NotNull] ITokenGenerator tokenGenerator)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
        }

        [Route("login")]
        [HttpPost]        
        public async Task<IActionResult> Login(string username, string password)
        {
            logger.LogInformation("Request for creating new login token for user {usernane}", username);
            
            var token = await tokenGenerator.CreateTokenAsync(username, password);
            
            return token != null
                ? new ObjectResult(token)
                : (IActionResult) BadRequest();
        }
    }
}