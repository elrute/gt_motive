using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public sealed class CreateVehicleCommand(
        string plate,
        string brand,
        string model,
        DateOnly manufactureDate) : IRequest<IWebApiPresenter>
    {
        public string Plate { get; } = plate;

        public string Brand { get; } = brand;

        public string Model { get; } = model;

        public DateOnly ManufactureDate { get; } = manufactureDate;
    }
}
