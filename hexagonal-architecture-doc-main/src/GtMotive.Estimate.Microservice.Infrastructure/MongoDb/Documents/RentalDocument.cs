using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents
{
    public class RentalDocument
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid VehicleId { get; set; }

        public string PersonId { get; set; }

        public DateTime RentedAtUtc { get; set; }

        public DateTime? ReturnedAtUtc { get; set; }
    }
}
