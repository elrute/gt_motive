using System;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class RentVehiclePresenter : IRentVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void InvalidHandle(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            ActionResult = new BadRequestObjectResult(message);
        }

        public void NotFoundHandle(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(RentVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            ActionResult = new OkObjectResult(new RentVehicleResponse(
                response.RentalId,
                response.VehicleId,
                response.PersonId,
                response.RentedAtUtc));
        }
    }
}
