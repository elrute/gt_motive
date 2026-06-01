using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public sealed class CreateVehicleFlowSpecs(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        [Fact]
        public async Task CreateVehicleThenListAvailableIncludesTheNewVehicle()
        {
            await ClearCollections();

            var plate = $"TEST-{Guid.NewGuid():N}"[..12];
            var createdVehicleId = Guid.Empty;

            await Fixture.UsingHandlerForRequestResponse<CreateVehicleCommand, IWebApiPresenter>(async handler =>
            {
                var presenter = await handler.Handle(
                    new CreateVehicleCommand(
                        plate,
                        "Ford",
                        "Focus",
                        DateOnly.FromDateTime(DateTime.UtcNow)),
                    CancellationToken.None);

                var result = Assert.IsType<CreatedResult>(presenter.ActionResult);
                var response = Assert.IsType<VehicleResponse>(result.Value);
                createdVehicleId = response.VehicleId;
            });

            await Fixture.UsingHandlerForRequestResponse<ListAvailableVehiclesQuery, IWebApiPresenter>(async handler =>
            {
                var presenter = await handler.Handle(new ListAvailableVehiclesQuery(), CancellationToken.None);

                var result = Assert.IsType<OkObjectResult>(presenter.ActionResult);
                var vehicles = Assert.IsType<IReadOnlyCollection<VehicleResponse>>(result.Value, exactMatch: false);

                Assert.Contains(vehicles, vehicle => vehicle.VehicleId == createdVehicleId && vehicle.Plate == plate);
            });
        }

        private async Task ClearCollections()
        {
            await Fixture.UsingRepository<MongoService>(async mongoService =>
            {
                await mongoService.Database.GetCollection<BsonDocument>("vehicles")
                    .DeleteManyAsync(Builders<BsonDocument>.Filter.Empty);
                await mongoService.Database.GetCollection<BsonDocument>("rentals")
                    .DeleteManyAsync(Builders<BsonDocument>.Filter.Empty);
            });
        }
    }
}
