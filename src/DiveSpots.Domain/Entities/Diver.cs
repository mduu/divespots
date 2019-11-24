using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities
{
    public class Diver : EntityBase
    {
        public Diver(string shortName)
        {
            ShortName = shortName;
        }

        internal Diver()
        {
        }
        
        public string ShortName { get; internal set; }
    }
}