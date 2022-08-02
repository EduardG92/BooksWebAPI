using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientUnitOfWork _patientUnit;
        private readonly IMapper _mapper;
        public PatientController(IPatientUnitOfWork patientiUnit, IMapper mapper)
        {
            _patientUnit = patientiUnit ?? throw new ArgumentNullException(nameof(patientiUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
    }
}
