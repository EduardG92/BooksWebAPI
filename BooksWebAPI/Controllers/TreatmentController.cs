using AutoMapper;
using BooksWebAPI.Entities;
using BooksWebAPI.ExternalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebAPI.Controllers
{
    [Route("treatment")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentUnitOfWork _treatmentUnit;
        private readonly IMapper _mapper;

        public TreatmentController(ITreatmentUnitOfWork treatmentUnit, IMapper mapper)
        {
            _treatmentUnit = treatmentUnit ?? throw new ArgumentNullException(nameof(treatmentUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //#region Treatments
        [HttpGet]
        [Route("id", Name = "GetTreatment")]
        public IActionResult GetTreatment(Guid id)
        {
            var treatmentEntity= _treatmentUnit.Treatments.Get(id);
            if(treatmentEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TreatmentDTO>(treatmentEntity));
        }

        [HttpGet]
        [Route("", Name = "GetAllTreatments")]
        public IActionResult GetAllTreatments(Guid id)
        {
            var treatmentEntity = _treatmentUnit.Treatments.Get(id);
            if (treatmentEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<TreatmentDTO>>(treatmentEntity));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetTreatmentDetails")]
        public IActionResult GetTreatmentDetails(Guid id)
        {
            var treatmentEntity = _treatmentUnit.Treatments.GetTreatmentDetails(id);
            if (treatmentEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TreatmentDTO>(treatmentEntity));
        }

        [Route("add", Name = "Add a new treatment")]
        [HttpPost]

        public IActionResult AddTreatment([FromBody] TreatmentDTO treatment)
        {
            var treatmentEntity = _mapper.Map<Treatment>(treatment);
            _treatmentUnit.Treatments.Add(treatmentEntity);

            _treatmentUnit.Complete();

            _treatmentUnit.Treatments.Get(treatmentEntity.Id);

            return CreatedAtRoute("GetTreatment", 
                new { id = treatmentEntity.Id }, 
                _mapper.Map<TreatmentDTO>(treatmentEntity));
        }
    }
}
