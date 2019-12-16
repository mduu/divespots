namespace DiveSpots.DataContracts.Api.CountryDtos
{
    public class CreateCountryDto
    {
        public TranslationDto[]? Name { get; set; } = new TranslationDto[0];
    }
}