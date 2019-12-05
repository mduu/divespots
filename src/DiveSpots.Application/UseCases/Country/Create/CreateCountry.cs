using System.Collections.Generic;
using DiveSpots.Application.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.Application.UseCases.Country.Create
{
    public class CreateCountry : UseCaseWithOutputPort<CreateCountryInteractorOutput>
    {
        public CreateCountry(
            IOutputPort<CreateCountryInteractorOutput> outputPort,
            IEnumerable<TranslationData> name) 
            : base(outputPort)
        {
            Name = name;
        }

        public IEnumerable<TranslationData> Name { get; }
    }
}