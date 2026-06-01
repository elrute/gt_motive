using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle rental lifecycle.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="id">Rental identifier.</param>
        /// <param name="vehicleId">Rented vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        /// <param name="rentedAtUtc">Rental creation date in UTC.</param>
        public Rental(Guid id, Guid vehicleId, string personId, DateTime rentedAtUtc)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Rental id is required.", nameof(id));
            }

            if (vehicleId == Guid.Empty)
            {
                throw new ArgumentException("Vehicle id is required.", nameof(vehicleId));
            }

            if (string.IsNullOrWhiteSpace(personId))
            {
                throw new ArgumentException("Person id is required.", nameof(personId));
            }

            Id = id;
            VehicleId = vehicleId;
            PersonId = personId.Trim();
            RentedAtUtc = rentedAtUtc;
        }

        /// <summary>
        /// Gets rental identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets rented vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets person identifier.
        /// </summary>
        public string PersonId { get; }

        /// <summary>
        /// Gets rental start date in UTC.
        /// </summary>
        public DateTime RentedAtUtc { get; }

        /// <summary>
        /// Gets rental return date in UTC when present.
        /// </summary>
        public DateTime? ReturnedAtUtc { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the rental is active.
        /// </summary>
        public bool IsActive => !ReturnedAtUtc.HasValue;

        /// <summary>
        /// Marks the rental as returned.
        /// </summary>
        /// <param name="returnedAtUtc">Return date in UTC.</param>
        public void Return(DateTime returnedAtUtc)
        {
            if (ReturnedAtUtc.HasValue)
            {
                throw new DomainException($"Rental {Id} is already closed.");
            }

            if (returnedAtUtc < RentedAtUtc)
            {
                throw new ArgumentException("Return date cannot be earlier than rental date.", nameof(returnedAtUtc));
            }

            ReturnedAtUtc = returnedAtUtc;
        }
    }
}
