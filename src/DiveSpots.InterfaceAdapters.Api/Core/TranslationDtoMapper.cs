using System.Collections.Generic;
using System.Linq;
using DiveSpots.Application.Core;
using DiveSpots.DataContracts.Api;

namespace DiveSpots.InterfaceAdapters.Api.Core
{
    public static class TranslationDtoMapper
    {
        public static IEnumerable<TranslationData> MapTo(this IEnumerable<TranslationDto> translations)
            => translations?.Select(t => new TranslationData(t.IsoCode, t.Text));
    }
}