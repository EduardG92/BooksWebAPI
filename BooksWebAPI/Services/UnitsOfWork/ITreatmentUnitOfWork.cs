public interface ITreatmentUnitOfWork : IDisposable
{
    ITreatmentRepository Treatments { get; }
    IDoctorRepository Doctors { get; }
    int Complete();
}