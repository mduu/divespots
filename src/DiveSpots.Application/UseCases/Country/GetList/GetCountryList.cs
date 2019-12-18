using DiveSpots.SharedKernel;

namespace DiveSpots.Application.UseCases.Country.GetList
{
    public class GetCountryList : UseCaseWithOutputPort<GetCountryListInteractorOutput>
    {
        public GetCountryList(IOutputPort<GetCountryListInteractorOutput> outputPort) 
            : base(outputPort)
        {
        }
    }
}