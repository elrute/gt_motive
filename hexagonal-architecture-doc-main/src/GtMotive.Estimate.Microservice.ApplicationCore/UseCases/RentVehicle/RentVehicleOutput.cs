using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output message for vehicle rental.
    /// </summary>
    public sealed class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        /// <param name="rentedAtUtc">Rental date in UTC.</param>
        public RentVehicleOutput(Guid rentalId, Guid vehicleId, string personId, DateTime rentedAtUtc)
        {
            ArgumentNullException.ThrowIfNull(personId);

            RentalId = rentalId;
            VehicleId = vehicleId;
            PersonId = personId;
            RentedAtUtc = rentedAtUtc;
        }

        /// <summary>
        /// Gets rental identifier.
        /// </summary>
        public Guid RentalId { get; }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets person identifier.
        /// </summary>
        public string PersonId { get; }

        /// <summary>
        /// Gets rental date in UTC.
        /// </summary>
        public DateTime RentedAtUtc { get; }
    }
}
