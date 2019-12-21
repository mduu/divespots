using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Application.Core;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.SharedKernel;
using JetBrains.Annotations;
using MediatR;

namespace DiveSpots.Application.UseCases.Waters.GetList
{
    [UsedImplicitly]
    public class GetWaterListInteractor : IRequestHandler<GetWaterList, UseCaseResult>
    {
        private readonly IWaterRepository waterRepository;

        public GetWaterListInteractor(IWaterRepository waterRepository)
        {
            this.waterRepository = waterRepository;
        }

        public async Task<UseCaseResult> Handle(GetWaterList request, CancellationToken cancellationToken)
        {
            var waters = await waterRepository.GetAllByCountryAsync(request.CountryId);
            
            request.OutputPort.Output(
                new GetWaterListInteractorOutput(
                    waters.Select(w =>
                        new GetWaterListInteractorOutput.WaterListItem(
                            w.Id,
                            w.Name.MapTo(),
                            w.Description.MapTo()))));
            
            return UseCaseResult.Success();
        }
    }
}