using DiveSpots.Domain.ValueObjects;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry
{
    public class SpotCoordinates : ValueObject
    {
        public SpotCoordinates(Coordinate? entry = null, Coordinate? parking = null)
        {
            Entry = entry ?? Entry;
            Parking = parking ?? Parking;
        }

        public Coordinate? Entry { get; private set; }
        public Coordinate? Parking { get; private set; }
    }
}