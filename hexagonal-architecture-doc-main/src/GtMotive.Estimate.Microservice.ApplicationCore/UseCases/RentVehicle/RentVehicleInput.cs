using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input message for vehicle rental.
    /// </summary>
    public sealed class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        public RentVehicleInput(Guid vehicleId, string personId)
        {
            ArgumentNullException.ThrowIfNull(personId);

            VehicleId = vehicleId;
            PersonId = personId;
        }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets person identifier.
        /// </summary>
        public string PersonId { get; }
    }
}
