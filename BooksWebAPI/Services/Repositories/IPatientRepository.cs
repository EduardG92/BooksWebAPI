using BooksWebAPI.Entities;

public interface IPatientRepository : IRepository<Patient>
{
    IEnumerable<Patient> GetPatients();
}