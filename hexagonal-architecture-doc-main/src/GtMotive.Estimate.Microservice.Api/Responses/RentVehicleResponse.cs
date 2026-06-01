using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public sealed class RentVehicleResponse(
        Guid rentalId,
        Guid vehicleId,
        string personId,
        DateTime rentedAtUtc)
    {
        [Required]
        public Guid RentalId { get; } = rentalId;

        [Required]
        public Guid VehicleId { get; } = vehicleId;

        [Required]
        public string PersonId { get; } = personId;

        [Required]
        public DateTime RentedAtUtc { get; } = rentedAtUtc;
    }
}
