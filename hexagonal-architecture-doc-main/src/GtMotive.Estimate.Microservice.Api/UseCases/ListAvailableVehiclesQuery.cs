using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public sealed class ListAvailableVehiclesQuery : IRequest<IWebApiPresenter>
    {
    }
}
