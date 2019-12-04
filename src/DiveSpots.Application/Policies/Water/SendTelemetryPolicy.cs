using System.Threading;
using System.Threading.Tasks;
using DiveSpots.Application.Gateways.Telemetry;
using DiveSpots.Domain.Entities.WaterEntity.Events;
using JetBrains.Annotations;
using MediatR;

#pragma warning disable 1998

namespace DiveSpots.Application.Policies.Water
{
    [UsedImplicitly]
    public class SendTelemetryPolicy : INotificationHandler<WaterCreated>
    {
        private readonly ITelemetryService telemetryService;

        public SendTelemetryPolicy(ITelemetryService telemetryService)
        {
            this.telemetryService = telemetryService;
        }

        public async Task Handle(WaterCreated notification, CancellationToken cancellationToken)
        {
            telemetryService.TrackEvent(TelemetryEventNames.NewWaterCreated);
        }
    }
}