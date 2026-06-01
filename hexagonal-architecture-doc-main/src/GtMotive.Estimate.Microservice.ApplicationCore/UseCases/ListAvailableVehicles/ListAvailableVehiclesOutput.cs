using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Output message for listing available vehicles.
    /// </summary>
    public sealed class ListAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">Available vehicles.</param>
        public ListAvailableVehiclesOutput(IReadOnlyCollection<AvailableVehicleOutput> vehicles)
        {
            System.ArgumentNullException.ThrowIfNull(vehicles);

            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets available vehicles.
        /// </summary>
        public IReadOnlyCollection<AvailableVehicleOutput> Vehicles { get; }
    }
}
