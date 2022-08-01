using BooksWebAPI.Contexts;

public class TreatmentUnitOfWork: ITreatmentUnitOfWork
{
    private readonly MedITContext _context;
    public TreatmentUnitOfWork(MedITContext context, ITreatmentRepository treatments, IDoctorRepository doctors)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Treatments = treatments ?? throw new ArgumentNullException(nameof(context));
        Doctors = doctors ?? throw new ArgumentNullException(nameof(context));
    }
    public ITreatmentRepository Treatments { get; }
    public IDoctorRepository Doctors { get; }
    public int Complete()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
