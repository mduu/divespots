using DiveSpots.SharedKernel;

namespace DiveSpots.Domain.ValueObjects
{
    public class Translation : ValueObject
    {
        public Translation(string isoCode, string text)
        {
            IsoCode = isoCode;
            Text = text;
        }

        public string IsoCode { get; }
        public string Text { get; }
    }
}