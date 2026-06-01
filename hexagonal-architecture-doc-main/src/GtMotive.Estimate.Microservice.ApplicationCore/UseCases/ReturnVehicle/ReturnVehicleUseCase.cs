using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Returns a rented vehicle.
    /// </summary>
    public sealed class ReturnVehicleUseCase : IReturnVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IReturnVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="rentalRepository">Rental repository.</param>
        /// <param name="outputPort">Output port.</param>
        public ReturnVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentalRepository rentalRepository,
            IReturnVehicleOutputPort outputPort)
        {
            ArgumentNullException.ThrowIfNull(vehicleRepository);
            ArgumentNullException.ThrowIfNull(rentalRepository);
            ArgumentNullException.ThrowIfNull(outputPort);

            _vehicleRepository = vehicleRepository;
            _rentalRepository = rentalRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetById(input.VehicleId);
            if (vehicle == null)
            {
                _outputPort.NotFoundHandle($"Vehicle {input.VehicleId} was not found.");
                return;
            }

            var rental = await _rentalRepository.GetActiveByVehicleId(input.VehicleId);
            if (rental == null)
            {
                _outputPort.InvalidHandle($"Vehicle {input.VehicleId} does not have an active rental.");
                return;
            }

            try
            {
                vehicle.Return();
                rental.Return(DateTime.UtcNow);

                await _vehicleRepository.Update(vehicle);
                await _rentalRepository.Update(rental);

                _outputPort.StandardHandle(new ReturnVehicleOutput(
                    rental.Id,
                    vehicle.Id,
                    rental.ReturnedAtUtc.Value));
            }
            catch (VehicleNotRentedException exception)
            {
                _outputPort.InvalidHandle(exception.Message);
            }
        }
    }
}
