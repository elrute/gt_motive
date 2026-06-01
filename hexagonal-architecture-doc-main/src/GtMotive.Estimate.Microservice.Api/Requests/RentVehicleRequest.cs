using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public sealed class RentVehicleRequest
    {
        [Required]
        public string PersonId { get; set; }
    }
}
