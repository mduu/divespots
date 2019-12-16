using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry
{
    public class SpotFeatures : ValueObject
    {
        internal SpotFeatures(bool? hasToilets = null, bool? hasFireplace = null)
        {
            HasToilets = hasToilets ?? HasFireplace;
            HasFireplace = hasFireplace ?? HasFireplace;
        }
        
        public bool HasToilets { get; private set; }
        public bool HasFireplace { get; private set; }
    }
}