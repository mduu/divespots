using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.ValueObjects
{
    public class Coordinate : ValueObject
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }
    }
}