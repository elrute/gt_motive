using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public sealed class ReturnVehicleCommandHandler : IRequestHandler<ReturnVehicleCommand, IWebApiPresenter>
    {
        private readonly IReturnVehicleUseCase _useCase;
        private readonly ReturnVehiclePresenter _presenter;

        public ReturnVehicleCommandHandler(
            IReturnVehicleUseCase useCase,
            ReturnVehiclePresenter presenter)
        {
            ArgumentNullException.ThrowIfNull(useCase);
            ArgumentNullException.ThrowIfNull(presenter);

            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ReturnVehicleInput(request.VehicleId));
            return _presenter;
        }
    }
}
