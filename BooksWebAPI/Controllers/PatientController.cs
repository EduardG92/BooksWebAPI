using AutoMapper;
using BooksWebAPI.ExternalModels;
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
        [HttpGet]
        [Route("{id}", Name = "GetPatient")]
        public IActionResult GetPatient(int id)
        {
            var patientEntity = _patientUnit.Patient.Get(id);
            if (patientEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PatientDTO>(patientEntity));
        }
    }
}
