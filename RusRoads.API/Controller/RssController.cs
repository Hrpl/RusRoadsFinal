using Microsoft.AspNetCore.Mvc;
using RusRoads.Application.Services;
using RusRoads.Domen.XMLModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RusRoads.API.Controller
{
    [Route("")]
    [ApiController]
    public class RssController : ControllerBase
    {
        private readonly XmlService _services;

        public RssController(XmlService services)
        {
            _services = services;
        }

        // GET: 
        [HttpGet("rss")]
        public ActionResult<Rss> Get()
        {
            var rss = _services.CreateRss();
            return Ok(_services.Serialize(rss));
        }

    }
}
