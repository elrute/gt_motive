using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input message for vehicle return.
    /// </summary>
    public sealed class ReturnVehicleInput(Guid vehicleId) : IUseCaseInput
    {
        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;
    }
}
