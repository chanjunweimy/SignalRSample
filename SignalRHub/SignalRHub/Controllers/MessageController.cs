using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Model;
using System;

namespace SignalRHub.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody]MessageDto msg)
        {
            try
            {
                _hubContext.Clients.All.BroadcastMessage(msg.Type, msg.Payload);                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
