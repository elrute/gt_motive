using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public sealed class CreateVehicleRequest
    {
        [Required]
        public string Plate { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public DateOnly? ManufactureDate { get; set; }
    }
}
