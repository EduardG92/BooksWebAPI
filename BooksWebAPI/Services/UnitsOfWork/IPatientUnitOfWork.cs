public interface IPatientUnitOfWork : IDisposable
{
    IPatientRepository Patients { get; }

    int Complete();
}