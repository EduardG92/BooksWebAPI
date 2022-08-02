using AutoMapper;

namespace BooksWebAPI.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Entities.Patient, ExternalModels.PatientDTO>();
            CreateMap<ExternalModels.PatientDTO, Entities.Patient>();
        }
    }
}
