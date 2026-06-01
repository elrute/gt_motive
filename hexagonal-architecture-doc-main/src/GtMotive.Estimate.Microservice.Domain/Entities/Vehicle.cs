using System;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle in the renting fleet.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">Vehicle identifier.</param>
        /// <param name="plate">Vehicle plate.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="model">Vehicle model.</param>
        /// <param name="manufactureDate">Vehicle manufacture date.</param>
        public Vehicle(
            Guid id,
            string plate,
            string brand,
            string model,
            DateOnly manufactureDate)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Vehicle id is required.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(plate))
            {
                throw new ArgumentException("Vehicle plate is required.", nameof(plate));
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException("Vehicle brand is required.", nameof(brand));
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Vehicle model is required.", nameof(model));
            }

            EnsureManufactureDateIsValid(manufactureDate, DateOnly.FromDateTime(DateTime.UtcNow));

            Id = id;
            Plate = plate.Trim();
            Brand = brand.Trim();
            Model = model.Trim();
            ManufactureDate = manufactureDate;
            Status = VehicleStatus.Available;
        }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid Id { get; }

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

        /// <summary>
        /// Gets current vehicle status.
        /// </summary>
        public VehicleStatus Status { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is available.
        /// </summary>
        public bool IsAvailable => Status == VehicleStatus.Available;

        /// <summary>
        /// Marks the vehicle as rented.
        /// </summary>
        public void Rent()
        {
            if (!IsAvailable)
            {
                throw new VehicleAlreadyRentedException($"Vehicle {Id} is not available.");
            }

            Status = VehicleStatus.Rented;
        }

        /// <summary>
        /// Marks the vehicle as available again.
        /// </summary>
        public void Return()
        {
            if (IsAvailable)
            {
                throw new VehicleNotRentedException($"Vehicle {Id} is not currently rented.");
            }

            Status = VehicleStatus.Available;
        }

        private static void EnsureManufactureDateIsValid(DateOnly manufactureDate, DateOnly today)
        {
            if (manufactureDate > today)
            {
                throw new InvalidVehicleManufactureDateException("Vehicle manufacture date cannot be in the future.");
            }

            if (manufactureDate < today.AddYears(-5))
            {
                throw new InvalidVehicleManufactureDateException("Fleet only accepts vehicles manufactured within the last 5 years.");
            }
        }
    }
}
