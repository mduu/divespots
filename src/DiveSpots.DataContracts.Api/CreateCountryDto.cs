namespace DiveSpots.DataContracts.Api
{
    public class CreateCountryDto
    {
        public TranslationDto[]? Name { get; set; } = new TranslationDto[0];
    }
}