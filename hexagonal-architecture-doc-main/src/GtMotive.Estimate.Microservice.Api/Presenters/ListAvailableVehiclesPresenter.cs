using System;
using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class ListAvailableVehiclesPresenter : IListAvailableVehiclesOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListAvailableVehiclesOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            IReadOnlyCollection<VehicleResponse> vehicles =
            [
                .. response.Vehicles.Select(vehicle => new VehicleResponse(
                    vehicle.VehicleId,
                    vehicle.Plate,
                    vehicle.Brand,
                    vehicle.Model,
                    vehicle.ManufactureDate)),
            ];

            ActionResult = new OkObjectResult(vehicles);
        }
    }
}
