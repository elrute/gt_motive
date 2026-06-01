using System;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class ReturnVehiclePresenter : IReturnVehicleOutputPort, IWebApiPresenter
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

        public void StandardHandle(ReturnVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            ActionResult = new OkObjectResult(new ReturnVehicleResponse(
                response.RentalId,
                response.VehicleId,
                response.ReturnedAtUtc));
        }
    }
}
