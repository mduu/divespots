using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.Entities.SpotEntry
{
    public class SpotRatings : ValueObject
    {
        internal SpotRatings(
            int? beginners = null,
            int? advanced = null,
            int? tecDivers = null,
            int? entry = null,
            int? wrecksAndObjects = null,
            int? wall = null,
            int? cave = null,
            int? bbq = null,
            int? openSpace = null,
            int? families = null)
        {
            Beginners = beginners ?? Beginners;
            Advanced = advanced ?? Advanced;
            TecDivers = tecDivers ?? TecDivers;
            Entry = entry ?? Entry;
            WrecksAndObjects = wrecksAndObjects ?? WrecksAndObjects;
            Wall = wall ?? Wall;
            Cave = cave ?? Cave;
            Bbq = bbq ?? Bbq;
            OpenSpace = openSpace ?? OpenSpace;
            Families = families ?? Families;
        }

        internal SpotRatings()
        {
        }
            
        public int Beginners { get; private set; }
        public int Advanced { get; private set; }
        public int TecDivers { get; private set; }
        public int Entry { get; private set; }
        public int WrecksAndObjects { get; private set; }
        public int Wall { get; private set; }
        public int Cave { get; private set; }
        public int Bbq { get; private set; }
        public int OpenSpace { get; private set; }
        public int Families { get; private set; }
    }
}