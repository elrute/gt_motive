using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Lists available fleet vehicles.
    /// </summary>
    public sealed class ListAvailableVehiclesUseCase : IListAvailableVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IListAvailableVehiclesOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="outputPort">Output port.</param>
        public ListAvailableVehiclesUseCase(
            IVehicleRepository vehicleRepository,
            IListAvailableVehiclesOutputPort outputPort)
        {
            System.ArgumentNullException.ThrowIfNull(vehicleRepository);
            System.ArgumentNullException.ThrowIfNull(outputPort);

            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            System.ArgumentNullException.ThrowIfNull(input);

            var vehicles = await _vehicleRepository.ListAvailable();

            IReadOnlyCollection<AvailableVehicleOutput> outputVehicles =
            [
                .. vehicles.Select(vehicle => new AvailableVehicleOutput(
                    vehicle.Id,
                    vehicle.Plate,
                    vehicle.Brand,
                    vehicle.Model,
                    vehicle.ManufactureDate)),
            ];

            _outputPort.StandardHandle(new ListAvailableVehiclesOutput(outputVehicles));
        }
    }
}
