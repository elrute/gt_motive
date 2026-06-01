using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public sealed class VehicleResponse(
        Guid vehicleId,
        string plate,
        string brand,
        string model,
        DateOnly manufactureDate)
    {
        [Required]
        public Guid VehicleId { get; } = vehicleId;

        [Required]
        public string Plate { get; } = plate;

        [Required]
        public string Brand { get; } = brand;

        [Required]
        public string Model { get; } = model;

        [Required]
        public DateOnly ManufactureDate { get; } = manufactureDate;
    }
}
