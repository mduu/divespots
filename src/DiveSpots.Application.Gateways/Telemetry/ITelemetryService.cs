using System.Collections.Generic;
using JetBrains.Annotations;

namespace DiveSpots.Application.Gateways.Telemetry
{
    public interface ITelemetryService
    {
        void TrackEvent([NotNull] string name, IDictionary<string, string> data = null);
        void TrackEvent([NotNull] string name, [CanBeNull] object dataObject);
    }
}
