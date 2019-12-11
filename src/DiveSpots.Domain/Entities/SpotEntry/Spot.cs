using System;
using DiveSpots.Domain.Entities.SpotEntry.Events;
using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry
{
    public class Spot : EntityBase
    {
        public Spot(
            Guid waterId,
            string name,
            string? alternativeName,
            string description,
            string city,
            SpotDifficulty difficulty,
            string? entry,
            string? parking)
        {
            Id = Guid.NewGuid();
            WaterId = waterId;
            Name = name;
            AlternativeName = alternativeName;
            Descriptions = new SpotDescriptions(description);
            City = city;
            Difficulty = difficulty;
            Coordinates = new SpotCoordinates(entry, parking);
            
            RaiseDomainEvent(new SpotCreated(Id));
        }
        
        internal Spot()
        {
        }

        public void UpdateRatings(
            int beginners,
            int advanced,
            int tecDivers,
            int entry,
            int wrecksAndObjects,
            int wall,
            int cave,
            int bbq,
            int openSpace,
            int families)
        {
            Ratings = new SpotRatings(
                beginners,
                advanced,
                tecDivers,
                entry,
                wrecksAndObjects,
                wall,
                cave,
                bbq,
                openSpace,
                families);
            
            RaiseDomainEvent(new SpotUpdated(Id));
        }

        public void UpdateFeatures(bool hasToilets, bool hasFireplaces)
        {
            Features = new SpotFeatures(hasToilets, hasFireplaces);
            
            RaiseDomainEvent(new SpotUpdated(Id));
        }

        public string Name { get; private set; } = "";
        public string AlternativeName { get; private set; } = "";
        public Guid WaterId { get; private set; }
        public string City { get; private set; } = "";
        public SpotDifficulty Difficulty { get; private set; }
        public SpotCoordinates Coordinates { get; private set; } = new SpotCoordinates();
        public SpotDescriptions Descriptions { get; private set; } = new SpotDescriptions();
        public SpotRatings Ratings { get; private set; } = new SpotRatings();
        public SpotFeatures Features { get; private set; } = new SpotFeatures();
    }
}