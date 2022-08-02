using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebAPI.Controllers
{
    [Route("api/[controller]")]
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
    }
}
