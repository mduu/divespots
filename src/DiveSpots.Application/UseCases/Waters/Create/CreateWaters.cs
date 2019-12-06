using System;
using System.Collections.Generic;
using DiveSpots.Application.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.Application.UseCases.Waters.Create
{
    public class CreateWaters : UseCaseWithOutputPort<CreateWatersInteractorOutput>
    {
        public CreateWaters(IOutputPort<CreateWatersInteractorOutput> outputPort,
            Guid countryId,
            IEnumerable<TranslationData> name,
            IEnumerable<TranslationData> description)
            : base(outputPort)
        {
            CountryId = countryId;
            Name = name;
            Description = description;
        }

        public Guid CountryId { get; }
        public IEnumerable<TranslationData> Name { get; }
        public IEnumerable<TranslationData> Description { get; }
    }
}