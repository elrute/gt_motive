namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output port for vehicle rental.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound, IOutputPortInvalid
    {
    }
}
