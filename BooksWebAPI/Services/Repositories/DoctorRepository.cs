using BooksWebAPI.Contexts;
using BooksWebAPI.Entities;
using BooksWebAPI.Services.Repositories;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    private readonly MedITContext _context;
    public DoctorRepository(MedITContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
 
}