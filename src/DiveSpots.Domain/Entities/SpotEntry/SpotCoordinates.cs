using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry
{
    public class SpotCoordinates : ValueObject
    {
        internal SpotCoordinates(string? entry = null, string? parking = null)
        {
            Entry = entry ?? Entry;
            Parking = parking ?? Parking;
        }

        public string? Entry { get; private set; } = "";
        public string? Parking { get; private set; } = "";
    }
}