using BooksWebAPI.Contexts;
using BooksWebAPI.Entities;
using BooksWebAPI.Services.Repositories;


public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
{
    private readonly MedITContext _context;
    public TreatmentRepository(MedITContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public Treatment GetTreatmentDetails(Guid Id) 
    {
        return _context.Treatments;
    }
}