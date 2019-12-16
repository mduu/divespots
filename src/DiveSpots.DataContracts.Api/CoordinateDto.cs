namespace DiveSpots.DataContracts.Api
{
    public class CoordinateDto
    {
        public CoordinateDto(double latitude = 0, double longitude = 0)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }
    }
}