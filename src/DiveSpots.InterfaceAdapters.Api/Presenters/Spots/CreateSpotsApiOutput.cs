using System;

namespace DiveSpots.InterfaceAdapters.Api.Presenters.Spots
{
    public class CreateSpotsApiOutput
    {
        public CreateSpotsApiOutput(Guid spotId)
        {
            SpotId = spotId;
        }

        public Guid SpotId { get; }
    }
}