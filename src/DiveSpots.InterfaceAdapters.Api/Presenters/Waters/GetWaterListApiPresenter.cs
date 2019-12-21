using System.Linq;
using DiveSpots.Application.UseCases.Waters.GetList;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Waters
{
    public class GetWaterListApiPresenter : ObjectPresenter<GetWaterListApiOutput>, IOutputPort<GetWaterListInteractorOutput>
    {
        public void Output(GetWaterListInteractorOutput interactorOutput) =>
            SetOutputObject(
                new GetWaterListApiOutput(
                    interactorOutput.Waters.Select(w =>
                        new WaterOutputItem(
                            w.Id,
                            w.Name,
                            w.Description))));
    }
}