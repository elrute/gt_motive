using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public sealed class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, IWebApiPresenter>
    {
        private readonly ICreateVehicleUseCase _useCase;
        private readonly CreateVehiclePresenter _presenter;

        public CreateVehicleCommandHandler(
            ICreateVehicleUseCase useCase,
            CreateVehiclePresenter presenter)
        {
            ArgumentNullException.ThrowIfNull(useCase);
            ArgumentNullException.ThrowIfNull(presenter);

            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new CreateVehicleInput(
                request.Plate,
                request.Brand,
                request.Model,
                request.ManufactureDate));

            return _presenter;
        }
    }
}
