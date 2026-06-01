namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the invalid output port.
    /// </summary>
    public interface IOutputPortInvalid
    {
        /// <summary>
        /// Informs the request could not be processed because it is invalid.
        /// </summary>
        /// <param name="message">Text description.</param>
        void InvalidHandle(string message);
    }
}
