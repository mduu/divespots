using System.Threading.Tasks;
using DiveSpots.Application.UseCases.Country.Create;
using DiveSpots.DataContracts.Api;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.InterfaceAdapters.Api.Presenters.Countries;
using DiveSpots.Web.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiveSpots.Web.api.Controllers
{
    [Route("api/v1/countries")]
    public class CountryController : ApiControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger logger;

        public CountryController(IMediator mediator, ILogger<CountryController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> CreateNewCountry([FromBody] CreateCountryDto country)
        {
            using var logScope = logger.BeginScope("Begin {name}", nameof(CreateNewCountry), country);

            if (country == null)
            {
                return BadRequest();
            }

            var presenter = new CreateCountryApiPresenter();

            return CreatedResult(
                await mediator.Send(
                    new CreateCountry(
                        presenter,
                        country.Name.MapTo())),
                presenter);
        }
    }
}