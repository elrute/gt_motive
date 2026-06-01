using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public sealed class ReturnVehicleResponse(
        Guid rentalId,
        Guid vehicleId,
        DateTime returnedAtUtc)
    {
        [Required]
        public Guid RentalId { get; } = rentalId;

        [Required]
        public Guid VehicleId { get; } = vehicleId;

        [Required]
        public DateTime ReturnedAtUtc { get; } = returnedAtUtc;
    }
}
