using BooksWebAPI.Contexts;
using BooksWebAPI.Entities;
using BooksWebAPI.Services.Repositories;
using Microsoft.EntityFrameworkCore;

public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
{
    private readonly MedITContext _context;
    public TreatmentRepository(MedITContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public Treatment GetTreatmentDetails(Guid Id) 
    {
        return _context.Treatments.Where(b => b.Id == Id && (b.Suspended == false || b.Suspended == null)).Include(b => b.Doctor).FirstOrDefault();
    }
}