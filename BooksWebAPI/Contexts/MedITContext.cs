using BooksWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksWebAPI.Contexts
{
    public class MedITContext : DbContext
    {
        public MedITContext(DbContextOptions<MedITContext> options)
            : base(options)
        { 
        
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

    }
}
