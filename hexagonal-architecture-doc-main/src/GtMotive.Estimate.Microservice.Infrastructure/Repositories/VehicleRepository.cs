using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<VehicleDocument> _vehicles;

        public VehicleRepository(MongoService mongoService)
        {
            ArgumentNullException.ThrowIfNull(mongoService);

            _vehicles = mongoService.Database.GetCollection<VehicleDocument>("vehicles");
        }

        public async Task Add(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            await _vehicles.InsertOneAsync(ToDocument(vehicle));
        }

        public async Task<Vehicle> GetById(Guid vehicleId)
        {
            var document = await _vehicles
                .Find(vehicle => vehicle.Id == vehicleId)
                .FirstOrDefaultAsync();

            return document == null ? null : ToDomain(document);
        }

        public async Task<IReadOnlyCollection<Vehicle>> ListAvailable()
        {
            var documents = await _vehicles
                .Find(vehicle => vehicle.Status == Domain.Enums.VehicleStatus.Available)
                .ToListAsync();

            var vehicles = new List<Vehicle>(documents.Count);
            foreach (var document in documents)
            {
                vehicles.Add(ToDomain(document));
            }

            return vehicles;
        }

        public async Task Update(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            await _vehicles.ReplaceOneAsync(
                document => document.Id == vehicle.Id,
                ToDocument(vehicle));
        }

        private static VehicleDocument ToDocument(Vehicle vehicle)
        {
            return new VehicleDocument
            {
                Id = vehicle.Id,
                Plate = vehicle.Plate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                ManufactureDateUtc = vehicle.ManufactureDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc),
                Status = vehicle.Status,
            };
        }

        private static Vehicle ToDomain(VehicleDocument document)
        {
            var vehicle = new Vehicle(
                document.Id,
                document.Plate,
                document.Brand,
                document.Model,
                DateOnly.FromDateTime(document.ManufactureDateUtc));

            if (document.Status == Domain.Enums.VehicleStatus.Rented)
            {
                vehicle.Rent();
            }

            return vehicle;
        }
    }
}
