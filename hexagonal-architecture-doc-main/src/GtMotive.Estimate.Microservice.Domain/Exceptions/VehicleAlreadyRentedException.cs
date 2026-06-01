namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when trying to rent a vehicle that is not available.
    /// </summary>
    public sealed class VehicleAlreadyRentedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        public VehicleAlreadyRentedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public VehicleAlreadyRentedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public VehicleAlreadyRentedException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
