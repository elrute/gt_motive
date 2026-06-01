namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output port for vehicle return.
    /// </summary>
    public interface IReturnVehicleOutputPort : IOutputPortStandard<ReturnVehicleOutput>, IOutputPortNotFound, IOutputPortInvalid
    {
    }
}
