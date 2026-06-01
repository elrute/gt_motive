using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public sealed class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Required] CreateVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var presenter = await _mediator.Send(new CreateVehicleCommand(
                request.Plate,
                request.Brand,
                request.Model,
                request.ManufactureDate.Value));

            return presenter.ActionResult;
        }

        [HttpGet("available")]
        public async Task<IActionResult> ListAvailable()
        {
            var presenter = await _mediator.Send(new ListAvailableVehiclesQuery());
            return presenter.ActionResult;
        }

        [HttpPost("{vehicleId:guid}/rent")]
        public async Task<IActionResult> Rent(Guid vehicleId, [FromBody][Required] RentVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var presenter = await _mediator.Send(new RentVehicleCommand(vehicleId, request.PersonId));
            return presenter.ActionResult;
        }

        [HttpPost("{vehicleId:guid}/return")]
        public async Task<IActionResult> Return(Guid vehicleId)
        {
            var presenter = await _mediator.Send(new ReturnVehicleCommand(vehicleId));
            return presenter.ActionResult;
        }
    }
}
