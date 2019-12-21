using System;
using DiveSpots.SharedKernel;

namespace DiveSpots.Application.UseCases.Waters.GetList
{
    public class GetWaterList : UseCaseWithOutputPort<GetWaterListInteractorOutput>
    {
        public GetWaterList(
            IOutputPort<GetWaterListInteractorOutput> outputPort,
            Guid countryId)
            : base(outputPort)
        {
            CountryId = countryId;
        }

        public Guid CountryId { get; }
    }
}