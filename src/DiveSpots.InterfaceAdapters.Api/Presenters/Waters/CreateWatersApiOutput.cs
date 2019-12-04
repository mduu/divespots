using System;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Waters
{
    public class CreateWatersApiOutput
    {
        public CreateWatersApiOutput(Guid waterId)
        {
            WaterId = waterId;
        }

        public Guid WaterId { get; }
    }
}