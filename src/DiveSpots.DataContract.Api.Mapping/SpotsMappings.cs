using System.Collections.Generic;
using DiveSpots.DataContracts.Api.SpotDtos;
using DiveSpots.Domain.Entities.SpotEntry;
using DiveSpots.Domain.ValueObjects;

namespace DiveSpots.DataContract.Api.Mapping
{
    public static class SpotsMappings
    {
        public static SpotDescriptions MapTo(this SpotDescriptionsDto dto) =>
            new SpotDescriptions(
                dto.Description,
                dto.Underwater,
                dto.Travel,
                dto.Risks,
                dto.Restaurants);

        public static SpotDifficulty MapTo(this SpotDifficultyDto dto) => DifficultyMapping[dto];
        
        public static SpotCoordinates MapTo(this SpotCoordinatesDto dto) =>
            new SpotCoordinates(
                new Coordinate(dto.Entry.Latitude, dto.Entry.Longitude),
                new Coordinate(dto.Parking.Latitude, dto.Parking.Longitude));

        private static readonly IDictionary<SpotDifficultyDto, SpotDifficulty> DifficultyMapping = new Dictionary<SpotDifficultyDto, SpotDifficulty>
        {
            {SpotDifficultyDto.Easy, SpotDifficulty.Easy},
            {SpotDifficultyDto.Medium, SpotDifficulty.Medium},
            {SpotDifficultyDto.Hard, SpotDifficulty.Hard},
        };
    }
}