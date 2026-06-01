using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public sealed class RentVehicleCommand(Guid vehicleId, string personId) : IRequest<IWebApiPresenter>
    {
        public Guid VehicleId { get; } = vehicleId;

        public string PersonId { get; } = personId;
    }
}
