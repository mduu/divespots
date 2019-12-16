using System;

namespace DiveSpots.DataContracts.Api.WaterDtos
{
    public class CreateWaterDto
    {
        public Guid CountryId { get; set; }
        public TranslationDto[]? Name { get; set; } = new TranslationDto[0];
        public TranslationDto[]? Description { get; set; } = new TranslationDto[0];
    }
}