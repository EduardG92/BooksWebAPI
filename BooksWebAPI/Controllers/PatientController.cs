using AutoMapper;
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

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO patient)
        {
            if(User == null)
            {
                return BadRequest("Invalid client request.");
            }

            var foundPatient = _patientUnit.Patient.FindDefault(u => u.Email.Equals(patient.Email) && u.Password.Equals(patient.Password) && (u.Deleted == false || u.Deleted == null));
            if (foundPatient.Count() == 1)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKey@2020"));
           var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var takeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44318",
                    audience: "https://localhost:44318",
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
