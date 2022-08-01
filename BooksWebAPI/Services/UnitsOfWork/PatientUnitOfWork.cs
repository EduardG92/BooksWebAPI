using BooksWebAPI.Contexts;

public class PatientUnitOfWork : IPatientUnitOfWork
{
    private readonly MedITContext _context;
    public PatientUnitOfWork(MedITContext context, IPatientRepository patients)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Patients = patients ?? throw new ArgumentNullException(nameof(context));
    }

    public IPatientRepository Patients { get; }

    public IPatientRepository Patient => throw new NotImplementedException();

    public int Complete()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}