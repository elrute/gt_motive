using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    public sealed class VehiclesControllerSpecs(GenericInfrastructureTestServerFixture fixture) : InfrastructureTestBase(fixture)
    {
        [Fact]
        public async Task PostCreateWhenManufactureDateIsMissingReturnsBadRequest()
        {
            using var client = Fixture.Server.CreateClient();
            var payload = JsonSerializer.Serialize(new
            {
                plate = "TEST-001",
                brand = "Ford",
                model = "Focus",
            });
            using var content = new StringContent(
                payload,
                Encoding.UTF8,
                "application/json");

            using var response = await client.PostAsync(new System.Uri("/vehicles", System.UriKind.Relative), content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
