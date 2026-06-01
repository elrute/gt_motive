namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when a person already has an active rental.
    /// </summary>
    public sealed class PersonAlreadyHasActiveRentalException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonAlreadyHasActiveRentalException"/> class.
        /// </summary>
        public PersonAlreadyHasActiveRentalException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonAlreadyHasActiveRentalException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public PersonAlreadyHasActiveRentalException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonAlreadyHasActiveRentalException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public PersonAlreadyHasActiveRentalException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
