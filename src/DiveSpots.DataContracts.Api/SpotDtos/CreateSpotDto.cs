using System;

namespace DiveSpots.DataContracts.Api.SpotDtos
{
    public class CreateSpotDto
    {
        public Guid WaterId { get; set; }
        public string Name { get; set; } = "";
        public string AlternativeName { get; set; } = "";
        public SpotDescriptionsDto Description { get; set; } = new SpotDescriptionsDto();
        public string City { get; set; } = "";
        public SpotDifficultyDto Difficulty { get; set; }
        public SpotCoordinatesDto Coordinates { get; set; } = new SpotCoordinatesDto();
    }
}