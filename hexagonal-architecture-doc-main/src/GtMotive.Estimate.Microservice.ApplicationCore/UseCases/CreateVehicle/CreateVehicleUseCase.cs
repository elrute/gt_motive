using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Creates a new fleet vehicle.
    /// </summary>
    public sealed class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICreateVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="outputPort">Output port.</param>
        public CreateVehicleUseCase(
            IVehicleRepository vehicleRepository,
            ICreateVehicleOutputPort outputPort)
        {
            ArgumentNullException.ThrowIfNull(vehicleRepository);
            ArgumentNullException.ThrowIfNull(outputPort);

            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                var vehicle = new Vehicle(Guid.NewGuid(), input.Plate, input.Brand, input.Model, input.ManufactureDate);

                await _vehicleRepository.Add(vehicle);

                _outputPort.StandardHandle(new CreateVehicleOutput(
                    vehicle.Id,
                    vehicle.Plate,
                    vehicle.Brand,
                    vehicle.Model,
                    vehicle.ManufactureDate));
            }
            catch (InvalidVehicleManufactureDateException exception)
            {
                _outputPort.InvalidHandle(exception.Message);
            }
        }
    }
}
