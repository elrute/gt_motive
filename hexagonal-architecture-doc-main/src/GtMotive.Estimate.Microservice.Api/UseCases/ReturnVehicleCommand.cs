using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public sealed class ReturnVehicleCommand(Guid vehicleId) : IRequest<IWebApiPresenter>
    {
        public Guid VehicleId { get; } = vehicleId;
    }
}
