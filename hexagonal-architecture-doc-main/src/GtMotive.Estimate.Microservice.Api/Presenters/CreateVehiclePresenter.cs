using System;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class CreateVehiclePresenter : ICreateVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void InvalidHandle(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(CreateVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            ActionResult = new CreatedResult(
                $"/vehicles/{response.VehicleId}",
                new VehicleResponse(
                    response.VehicleId,
                    response.Plate,
                    response.Brand,
                    response.Model,
                    response.ManufactureDate));
        }
    }
}
