using DiveSpots.Application.UseCases.Waters.Create;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Waters
{
    public class CreateWatersApiPresenter : ObjectPresenter<CreateWatersApiOutput>, IOutputPort<CreateWatersInteractorOutput>
    {
        public void Output(CreateWatersInteractorOutput interactorOutput) 
            => SetOutputObject(new CreateWatersApiOutput(interactorOutput.WatersId));
    }
}