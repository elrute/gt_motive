using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    public sealed class RentVehicleUseCaseTests
    {
        [Fact]
        public async Task ExecuteWhenPersonAlreadyHasAnActiveRentalWritesInvalidOutput()
        {
            var vehicleRepository = new Mock<IVehicleRepository>();
            var rentalRepository = new Mock<IRentalRepository>();
            var outputPort = new Mock<IRentVehicleOutputPort>();

            var vehicle = new Vehicle(
                Guid.NewGuid(),
                "TEST-UNIT-001",
                "Ford",
                "Focus",
                DateOnly.FromDateTime(DateTime.UtcNow));

            vehicleRepository
                .Setup(repository => repository.GetById(vehicle.Id))
                .ReturnsAsync(vehicle);

            rentalRepository
                .Setup(repository => repository.GetActiveByPersonId("person-1"))
                .ReturnsAsync(new Rental(Guid.NewGuid(), Guid.NewGuid(), "person-1", DateTime.UtcNow));

            var useCase = new RentVehicleUseCase(
                vehicleRepository.Object,
                rentalRepository.Object,
                outputPort.Object);

            await useCase.Execute(new RentVehicleInput(vehicle.Id, "person-1"));

            outputPort.Verify(port => port.InvalidHandle(It.Is<string>(message => message.Contains("person-1"))), Times.Once);
            rentalRepository.Verify(repository => repository.Add(It.IsAny<Rental>()), Times.Never);
            vehicleRepository.Verify(repository => repository.Update(It.IsAny<Vehicle>()), Times.Never);
        }
    }
}
