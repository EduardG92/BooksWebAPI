using BooksWebAPI.Entities;

public interface ITreatmentRepository : IRepository<Patient>
{
   Treatment GetTreatmentDetails(Guid Id);
}