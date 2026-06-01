using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents
{
    public class RentalDocument
    {
        [BsonId]
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        public string PersonId { get; set; }

        public DateTime RentedAtUtc { get; set; }

        public DateTime? ReturnedAtUtc { get; set; }
    }
}
