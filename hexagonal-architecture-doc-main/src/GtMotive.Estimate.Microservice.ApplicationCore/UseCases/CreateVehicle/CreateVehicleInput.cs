using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Input message for vehicle creation.
    /// </summary>
    public sealed class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="plate">Vehicle plate.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="model">Vehicle model.</param>
        /// <param name="manufactureDate">Vehicle manufacture date.</param>
        public CreateVehicleInput(string plate, string brand, string model, DateOnly manufactureDate)
        {
            ArgumentNullException.ThrowIfNull(plate);
            ArgumentNullException.ThrowIfNull(brand);
            ArgumentNullException.ThrowIfNull(model);

            Plate = plate;
            Brand = brand;
            Model = model;
            ManufactureDate = manufactureDate;
        }

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
