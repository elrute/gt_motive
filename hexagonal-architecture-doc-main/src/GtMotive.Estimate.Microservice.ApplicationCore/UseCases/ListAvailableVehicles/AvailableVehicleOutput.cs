using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Available vehicle data.
    /// </summary>
    public sealed class AvailableVehicleOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="plate">Vehicle plate.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="model">Vehicle model.</param>
        /// <param name="manufactureDate">Vehicle manufacture date.</param>
        public AvailableVehicleOutput(Guid vehicleId, string plate, string brand, string model, DateOnly manufactureDate)
        {
            ArgumentNullException.ThrowIfNull(plate);
            ArgumentNullException.ThrowIfNull(brand);
            ArgumentNullException.ThrowIfNull(model);

            VehicleId = vehicleId;
            Plate = plate;
            Brand = brand;
            Model = model;
            ManufactureDate = manufactureDate;
        }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets vehicle plate.
        /// </summary>
        public string Plate { get; }

        /// <summary>
        /// Gets vehicle brand.
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// Gets vehicle model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Gets vehicle manufacture date.
        /// </summary>
        public DateOnly ManufactureDate { get; }
    }
}
