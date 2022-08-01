public interface IPatientUnitOfWork : IDisposable
{
    IPatientRepository Patient { get; }

    int Complete();
}