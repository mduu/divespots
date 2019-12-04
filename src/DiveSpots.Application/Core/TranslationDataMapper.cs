using System.Collections.Generic;
using System.Linq;
using DiveSpots.Domain.ValueObjects;

namespace DiveSpots.Application.Core
{
    public static class TranslationDataMapper
    {
        public static ICollection<Translation> MapTo(this IEnumerable<TranslationData> translations)
            => translations
                .Select(t => new Translation(t.IsoCode, t.Text))
                .ToList();

        public static IEnumerable<TranslationData> MapTo(this IEnumerable<Translation> translations)
            => translations
                .Select(t => new TranslationData(t.IsoCode, t.Text));
    }
}