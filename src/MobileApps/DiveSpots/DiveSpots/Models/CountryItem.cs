using System;
namespace DiveSpots.Models
{
    public class CountryItem
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
