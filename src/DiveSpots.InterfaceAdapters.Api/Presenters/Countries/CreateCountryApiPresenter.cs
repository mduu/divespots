using DiveSpots.Application.UseCases.Country.Create;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Countries
{
    public class CreateCountryApiPresenter : ObjectPresenter<CreateCountryApiOutput>, IOutputPort<CreateCountryInteractorOutput>
    {
        public void Output(CreateCountryInteractorOutput interactorOutput)
            => SetOutputObject(new CreateCountryApiOutput(interactorOutput.CountryId));
    }
}