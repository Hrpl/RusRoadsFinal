using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RusRoads.Application.Hubs;
using RusRoads.Application.Services;
using RusRoads.Domen.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RusRoads.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly NewsService _service;

        public NewsController(IHubContext<ChatHub> hubContext, NewsService service)
        {
            _hubContext = hubContext;
            _service = service;
        }

        //GET: api/<NewsController> 

        [Authorize]
        [HttpPost("addNews")]
        public async Task<ActionResult> AddNewsPost(News news)
        {
            bool isSucces = await _service.AddNews(news);
            if (isSucces)
            {
                _hubContext.Clients.All.SendAsync("Message", news.Title);
                return Ok();

            }
            else return BadRequest();
        }

        //GET: api/filter

        [Authorize]
        [HttpGet("filter")]
        public async Task<ActionResult> FilterNewsGet(string type)
        {
            var listNew = await _service.FilterOnType(type);
            if (listNew != null)
            {
                
                return Ok(listNew);

            }
            else return BadRequest(listNew);
        }
    }
}
