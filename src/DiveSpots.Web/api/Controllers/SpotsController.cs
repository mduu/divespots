using System.Threading.Tasks;
using DiveSpots.Application.UseCases.Spots.Create;
using DiveSpots.DataContract.Api.Mapping;
using DiveSpots.DataContracts.Api.SpotDtos;
using DiveSpots.InterfaceAdapters.Api.Presenters.Spots;
using DiveSpots.Web.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveSpots.Web.api.Controllers
{
    [Route("api/v1/spots")]
    public class SpotsController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public SpotsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> CreateWaters([FromBody] CreateSpotDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            
            var presenter = new CreateSpotsApiPresenter();

            return CreateResult(
                await mediator.Send(
                    new CreateSpot(
                        presenter,
                        dto.WaterId,
                        dto.Name,
                        dto.AlternativeName,
                        dto.Description.MapTo(),
                        dto.City,
                        dto.Difficulty.MapTo(),
                        dto.Coordinates.MapTo())),
                presenter);

        }
    }
}