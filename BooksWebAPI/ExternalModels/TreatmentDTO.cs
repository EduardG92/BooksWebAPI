namespace BooksWebAPI.ExternalModels
{
    public class TreatmentDTO
    {
        public Guid Id { get; set; }
        public string TreatmentName { get; set; }
        public string Description { get; set; }
        public Guid DoctorID { get; set; }
        public DoctorDTO Doctor { get; set; }
    }
}