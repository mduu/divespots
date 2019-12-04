using System;
using System.Collections.Generic;
using System.Linq;
using DiveSpots.Application.Gateways.Telemetry;
using JetBrains.Annotations;
using Microsoft.ApplicationInsights;

namespace DiveSpots.Drivers.AppInsights
{
    /// <summary>
    /// <see cref="ITelemetryService"/> implementation using Application Insights.
    /// </summary>
    internal class AppInsightsTelemetryService : ITelemetryService
    {
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tauchbolde.Common.Telemetry.AppInsightsTelemetryService"/> class.
        /// </summary>
        /// <param name="telemetryClient">Telemetry client.</param>
        public AppInsightsTelemetryService(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }

        /// <inheritdoc/>
        public void TrackEvent(string name, IDictionary<string, string>? data = null)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            telemetryClient.TrackEvent(name, data);
        }

        /// <inheritdoc/>
        public void TrackEvent([System.Diagnostics.CodeAnalysis.NotNull] string name, [CanBeNull] object dataObject)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            if (dataObject == null)
            {
                TrackEvent(name);
                return;
            }
            
            var dataObjectType = dataObject.GetType();
            var propInfos = dataObjectType.GetProperties();
            var dataValues = propInfos?
                .ToDictionary(p => 
                    p.Name, 
                    p => Convert.ToString(p.GetValue(dataObject)));

            TrackEvent(name, dataValues);
        }
    }
}
