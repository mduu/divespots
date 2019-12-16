using System;
using DiveSpots.Domain.Entities.SpotEntry;
using DiveSpots.SharedKernel;

namespace DiveSpots.Application.UseCases.Spots.Create
{
    public class CreateSpot : UseCaseWithOutputPort<CreateSpotInteractorOutput>
    {
        public CreateSpot(
            IOutputPort<CreateSpotInteractorOutput> outputPort,
            Guid waterId,
            string name,
            string? alternativeName,
            SpotDescriptions description,
            string city,
            SpotDifficulty difficulty,
            SpotCoordinates coordinates) 
            : base(outputPort)
        {
            WaterId = waterId;
            Name = name;
            AlternativeName = alternativeName;
            Description = description;
            City = city;
            Difficulty = difficulty;
            Coordinates = coordinates;
        }

        public Guid WaterId { get; }
        public string Name { get; }
        public string? AlternativeName { get; }
        public SpotDescriptions Description { get; }
        public string City { get; }
        public SpotDifficulty Difficulty { get; }
        public SpotCoordinates Coordinates { get; }
    }
}