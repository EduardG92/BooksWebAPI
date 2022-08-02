using AutoMapper;

namespace BooksWebAPI.Profiles
{
    public class TreatmentProfile : Profile
    {
        public TreatmentProfile()
        {
            CreateMap<Entities.Doctor, ExternalModels.DoctorDTO>();
            CreateMap<ExternalModels.DoctorDTO, Entities.Doctor>();

            CreateMap<Entities.Treatment, ExternalModels.TreatmentDTO>();
            CreateMap<ExternalModels.TreatmentDTO, Entities.Treatment>();

        }
    }
}
