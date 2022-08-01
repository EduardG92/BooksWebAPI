using BooksWebAPI.Contexts;
using BooksWebAPI.Entities;
using BooksWebAPI.Services.Repositories;


public class PatientRepository : Repository<Patient>, IPatientRepository
{
    private readonly MedITContext _context;
    public PatientRepository(MedITContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public IEnumerable<Patient> GetPatients()
    {
        return _context.Patients;
    }
}