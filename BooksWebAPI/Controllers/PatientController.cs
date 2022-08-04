using AutoMapper;
using BooksWebAPI.Entities;
using BooksWebAPI.ExternalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientUnitOfWork _patientUnit;
        private readonly IMapper _mapper;

        public PatientController(IPatientUnitOfWork patientUnit, IMapper mapper)
        {
            _patientUnit = patientUnit ?? throw new ArgumentNullException(nameof(patientUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}", Name = "GetPatient")]
        public IActionResult GetPatient(Guid id)
        {
            var patientEntity = _patientUnit.Patients.Get(id);
            if (patientEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PatientDTO>(patientEntity));
        }

        [HttpGet]
        [Route("", Name = "GetAllPatients")]
        public IActionResult GetAllPatients(Guid id)
        {
            var patientEntities = _patientUnit.Patients.Find(u => u.Deleted == false || u.Deleted == null);
            if (patientEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<PatientDTO>>(patientEntities));
        }


        [Route("register", Name = "Register a new account")]
        [HttpPost]
        public IActionResult Register([FromBody] PatientDTO patient)
        {
            var patientEntity = _mapper.Map<Patient>(patient);
            _patientUnit.Patients.Add(patientEntity);
            _patientUnit.Complete();
            _patientUnit.Patients.Get(patientEntity.Id);

            return CreatedAtRoute("GetPatient", 
                new { id = patientEntity.Id }, 
                _mapper.Map<PatientDTO>(patientEntity));

        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO patient)
        {
            if(patient == null)
            {
                return BadRequest("Invalid client request.");
            }

            var foundPatient = _patientUnit.Patients.FindDefault(u => u.Email.Equals(patient.Email) && u.Password.Equals(patient.Password) && (u.Deleted == false || u.Deleted == null));
            if (foundPatient != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKey@2020"));
           var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var takeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7045",
                    audience: "https://localhost:7045",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(8),
                    signingCredentials: signinCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(takeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
