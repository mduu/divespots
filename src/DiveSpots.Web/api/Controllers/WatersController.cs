using System;
using System.Threading.Tasks;
using DiveSpots.Application.UseCases.Waters.Create;
using DiveSpots.DataContracts.Api.WaterDtos;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.InterfaceAdapters.Api.Presenters.Waters;
using DiveSpots.Web.Core;
using JetBrains.Annotations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveSpots.Web.api.Controllers
{
    [Route("api/v1/waters")]
    public class WatersController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public WatersController([NotNull] IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

//        [HttpGet("")]
//        public IActionResult GetAllWaters()
//        {
//        }
//
//        [HttpGet("{waterId}")]
//        public IActionResult GetWaterById(Guid waterId)
//        {
//        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> CreateWaters([FromBody] CreateWaterDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var presenter = new CreateWatersApiPresenter();

            return CreateResult(
                await mediator.Send(
                    new CreateWaters(
                        presenter,
                        dto.CountryId,
                        dto.Name.MapTo(),
                        dto.Description.MapTo())),
                presenter);
        }
    }
}