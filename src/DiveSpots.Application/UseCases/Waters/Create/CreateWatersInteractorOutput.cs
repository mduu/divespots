using System;

namespace DiveSpots.Application.UseCases.Waters.Create
{
    public class CreateWatersInteractorOutput
    {
        public CreateWatersInteractorOutput(Guid watersId)
        {
            WatersId = watersId;
        }

        public Guid WatersId { get; }
    }
}