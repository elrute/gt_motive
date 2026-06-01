namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when a vehicle manufacture date is invalid for the fleet.
    /// </summary>
    public sealed class InvalidVehicleManufactureDateException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidVehicleManufactureDateException"/> class.
        /// </summary>
        public InvalidVehicleManufactureDateException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidVehicleManufactureDateException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidVehicleManufactureDateException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidVehicleManufactureDateException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidVehicleManufactureDateException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
