using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Vehicle repository port.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a vehicle to the fleet.
        /// </summary>
        /// <param name="vehicle">Vehicle to persist.</param>
        /// <returns>Task.</returns>
        Task Add(Vehicle vehicle);

        /// <summary>
        /// Gets a vehicle by identifier.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <returns>Vehicle when found, otherwise null.</returns>
        Task<Vehicle> GetById(Guid vehicleId);

        /// <summary>
        /// Lists the available vehicles.
        /// </summary>
        /// <returns>Available fleet vehicles.</returns>
        Task<IReadOnlyCollection<Vehicle>> ListAvailable();

        /// <summary>
        /// Updates an existing vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to update.</param>
        /// <returns>Task.</returns>
        Task Update(Vehicle vehicle);
    }
}
