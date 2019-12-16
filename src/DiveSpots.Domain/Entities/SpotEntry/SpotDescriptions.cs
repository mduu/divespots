using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry
{
    public class SpotDescriptions : ValueObject
    {
        public SpotDescriptions(
            string? description = null,
            string? underwater = null,
            string? travel = null,
            string? risks = null,
            string? restaurants = null)
        {
            Description = description ?? Description;
            Underwater = underwater ?? Underwater;
            Travel = travel ?? Travel;
            Risks = risks ?? Risks;
            Restaurants = restaurants ?? Restaurants;
        }

        public string Description { get; private set; } = "";
        public string Underwater { get; private set; } = "";
        public string Travel { get; private set; } = "";
        public string Risks { get; private set; } = "";
        public string Restaurants { get; private set; } = "";
    }
}