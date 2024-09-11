using Microsoft.AspNetCore.Mvc;
using TrenRezervasyon.Models;
using TrenRezervasyon.Services;

namespace TrenRezervasyon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RezervasyonController : ControllerBase
    {
        private readonly RezervasyonService _rezervasyonService;

        public RezervasyonController()
        {
            _rezervasyonService = new RezervasyonService();
        }

        [HttpPost]
        public ActionResult<RezervasyonResponse> RezervasyonYap([FromBody] RezervasyonRequest request)
        {
            var result = _rezervasyonService.RezervasyonYap(request);

            if (result.RezervasyonYapilabilir)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
