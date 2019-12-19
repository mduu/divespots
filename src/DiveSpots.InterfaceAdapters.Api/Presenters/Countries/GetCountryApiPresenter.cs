using System.Linq;
using DiveSpots.Application.UseCases.Country.GetList;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Countries
{
    public class GetCountryApiPresenter : ObjectPresenter<GetCountryListApiOutput>, IOutputPort<GetCountryListInteractorOutput>
    {
        public void Output(GetCountryListInteractorOutput interactorOutput) =>
            SetOutputObject(
                new GetCountryListApiOutput(
                    interactorOutput.Countries.Select(c =>
                        new CountryOutputItem(
                            c.Id,
                            c.Name)).ToList()));
    }
}