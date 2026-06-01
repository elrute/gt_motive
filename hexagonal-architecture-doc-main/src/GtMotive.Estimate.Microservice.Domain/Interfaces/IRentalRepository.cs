using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Rental repository port.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Adds a rental.
        /// </summary>
        /// <param name="rental">Rental to persist.</param>
        /// <returns>Task.</returns>
        Task Add(Rental rental);

        /// <summary>
        /// Gets the active rental for a vehicle.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <returns>Active rental when found, otherwise null.</returns>
        Task<Rental> GetActiveByVehicleId(Guid vehicleId);

        /// <summary>
        /// Gets the active rental for a person.
        /// </summary>
        /// <param name="personId">Person identifier.</param>
        /// <returns>Active rental when found, otherwise null.</returns>
        Task<Rental> GetActiveByPersonId(string personId);

        /// <summary>
        /// Updates an existing rental.
        /// </summary>
        /// <param name="rental">Rental to update.</param>
        /// <returns>Task.</returns>
        Task Update(Rental rental);
    }
}
