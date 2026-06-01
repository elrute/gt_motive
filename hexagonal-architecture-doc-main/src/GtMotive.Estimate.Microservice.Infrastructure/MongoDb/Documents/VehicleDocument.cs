using System;
using GtMotive.Estimate.Microservice.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents
{
    public class VehicleDocument
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Plate { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufactureDateUtc { get; set; }

        public VehicleStatus Status { get; set; }
    }
}
