using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<RentalDocument> _rentals;

        public RentalRepository(MongoService mongoService)
        {
            ArgumentNullException.ThrowIfNull(mongoService);

            _rentals = mongoService.Database.GetCollection<RentalDocument>("rentals");
        }

        public async Task Add(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            await _rentals.InsertOneAsync(ToDocument(rental));
        }

        public async Task<Rental> GetActiveByVehicleId(Guid vehicleId)
        {
            var document = await _rentals
                .Find(rental => rental.VehicleId == vehicleId && rental.ReturnedAtUtc == null)
                .FirstOrDefaultAsync();

            return document == null ? null : ToDomain(document);
        }

        public async Task<Rental> GetActiveByPersonId(string personId)
        {
            ArgumentNullException.ThrowIfNull(personId);

            var document = await _rentals
                .Find(rental => rental.PersonId == personId && rental.ReturnedAtUtc == null)
                .FirstOrDefaultAsync();

            return document == null ? null : ToDomain(document);
        }

        public async Task Update(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            await _rentals.ReplaceOneAsync(
                document => document.Id == rental.Id,
                ToDocument(rental));
        }

        private static RentalDocument ToDocument(Rental rental)
        {
            return new RentalDocument
            {
                Id = rental.Id,
                VehicleId = rental.VehicleId,
                PersonId = rental.PersonId,
                RentedAtUtc = rental.RentedAtUtc,
                ReturnedAtUtc = rental.ReturnedAtUtc,
            };
        }

        private static Rental ToDomain(RentalDocument document)
        {
            var rental = new Rental(
                document.Id,
                document.VehicleId,
                document.PersonId,
                document.RentedAtUtc);

            if (document.ReturnedAtUtc.HasValue)
            {
                rental.Return(document.ReturnedAtUtc.Value);
            }

            return rental;
        }
    }
}
