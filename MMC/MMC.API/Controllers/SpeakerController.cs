using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMC.Application.Modules.Speakers.Query;

namespace MMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpeakerController(IMediator mediator)

        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var resulta = await _mediator.Send(new GetAllSpeaker());
            return Ok(resulta);
        }
      

    }
}
