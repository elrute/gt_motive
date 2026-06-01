namespace GtMotive.Estimate.Microservice.Domain.Enums
{
    /// <summary>
    /// Vehicle availability state.
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// Vehicle is available for rent.
        /// </summary>
        Available = 0,

        /// <summary>
        /// Vehicle is currently rented.
        /// </summary>
        Rented = 1,
    }
}
