using System.Collections.Generic;
using DiveSpots.Application.Core;
using DiveSpots.SharedKernel;

namespace DiveSpots.Application.UseCases.Waters.Create
{
    public class CreateWaters : UseCaseWithOutputPort<CreateWatersInteractorOutput>
    {
        public CreateWaters(
            IOutputPort<CreateWatersInteractorOutput> outputPort,
            IEnumerable<TranslationData> name,
            IEnumerable<TranslationData> description)
            : base(outputPort)
        {
            Name = name;
            Description = description;
        }
        
        public IEnumerable<TranslationData> Name { get; }
        public IEnumerable<TranslationData> Description { get; }
    }
}