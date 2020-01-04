using System;

namespace DiveSpots.Models
{
    public class WaterVisibillityOverview
    {
        public Guid WaterId { get; set; }
        public string WaterName { get; set; }
        public OverallTemperature Temperature { get; set; } = new OverallTemperature();
        public Visibility Visibility { get;set; }
        public MarineLife MarineLife { get;set; }
    }
}
