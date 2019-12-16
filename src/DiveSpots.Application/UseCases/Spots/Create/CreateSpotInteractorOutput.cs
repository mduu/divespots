using System;

namespace DiveSpots.Application.UseCases.Spots.Create
{
    public class CreateSpotInteractorOutput 
    {
        public CreateSpotInteractorOutput(Guid spotId)
        {
            SpotId = spotId;
        }
        
        public Guid SpotId { get; }
    }
}