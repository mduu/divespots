using DiveSpots.Application.UseCases.Spots.Create;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Spots
{
    public class CreateSpotsApiPresenter : ObjectPresenter<CreateSpotsApiOutput>, IOutputPort<CreateSpotInteractorOutput>
    {
        public void Output(CreateSpotInteractorOutput interactorOutput)
        {
            SetOutputObject(new CreateSpotsApiOutput(interactorOutput.SpotId));
        }
    }
}