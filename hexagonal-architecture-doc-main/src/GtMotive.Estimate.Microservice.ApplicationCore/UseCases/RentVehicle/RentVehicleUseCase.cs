using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Rents a vehicle to a person.
    /// </summary>
    public sealed class RentVehicleUseCase : IRentVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="rentalRepository">Rental repository.</param>
        /// <param name="outputPort">Output port.</param>
        public RentVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentalRepository rentalRepository,
            IRentVehicleOutputPort outputPort)
        {
            ArgumentNullException.ThrowIfNull(vehicleRepository);
            ArgumentNullException.ThrowIfNull(rentalRepository);
            ArgumentNullException.ThrowIfNull(outputPort);

            _vehicleRepository = vehicleRepository;
            _rentalRepository = rentalRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetById(input.VehicleId);
            if (vehicle == null)
            {
                _outputPort.NotFoundHandle($"Vehicle {input.VehicleId} was not found.");
                return;
            }

            var activeRental = await _rentalRepository.GetActiveByPersonId(input.PersonId);
            if (activeRental != null)
            {
                _outputPort.InvalidHandle($"Person {input.PersonId} already has an active rental.");
                return;
            }

            try
            {
                vehicle.Rent();

                var rental = new Rental(Guid.NewGuid(), vehicle.Id, input.PersonId, DateTime.UtcNow);

                await _rentalRepository.Add(rental);
                await _vehicleRepository.Update(vehicle);

                _outputPort.StandardHandle(new RentVehicleOutput(
                    rental.Id,
                    rental.VehicleId,
                    rental.PersonId,
                    rental.RentedAtUtc));
            }
            catch (VehicleAlreadyRentedException exception)
            {
                _outputPort.InvalidHandle(exception.Message);
            }
        }
    }
}
