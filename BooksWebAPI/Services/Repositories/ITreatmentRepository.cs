using BooksWebAPI.Entities;

public interface ITreatmentRepository : IRepository<Treatment>
{
   Treatment GetTreatmentDetails(Guid Id);
}