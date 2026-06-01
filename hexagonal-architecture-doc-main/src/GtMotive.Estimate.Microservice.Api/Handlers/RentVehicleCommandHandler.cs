using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public sealed class RentVehicleCommandHandler : IRequestHandler<RentVehicleCommand, IWebApiPresenter>
    {
        private readonly IRentVehicleUseCase _useCase;
        private readonly RentVehiclePresenter _presenter;

        public RentVehicleCommandHandler(
            IRentVehicleUseCase useCase,
            RentVehiclePresenter presenter)
        {
            ArgumentNullException.ThrowIfNull(useCase);
            ArgumentNullException.ThrowIfNull(presenter);

            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(RentVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new RentVehicleInput(request.VehicleId, request.PersonId));
            return _presenter;
        }
    }
}
