using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public sealed class ListAvailableVehiclesQueryHandler : IRequestHandler<ListAvailableVehiclesQuery, IWebApiPresenter>
    {
        private readonly IListAvailableVehiclesUseCase _useCase;
        private readonly ListAvailableVehiclesPresenter _presenter;

        public ListAvailableVehiclesQueryHandler(
            IListAvailableVehiclesUseCase useCase,
            ListAvailableVehiclesPresenter presenter)
        {
            ArgumentNullException.ThrowIfNull(useCase);
            ArgumentNullException.ThrowIfNull(presenter);

            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(ListAvailableVehiclesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ListAvailableVehiclesInput());
            return _presenter;
        }
    }
}
