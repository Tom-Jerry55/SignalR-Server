using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly TimerManager _timer;

        public ChartController(IHubContext<ChartHub> hub, TimerManager timer)
        {
            _hub = hub;
            _timer = timer;
        }
        [HttpGet]
        public IActionResult Get()
        {
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferChartData", DataManager.GetData()));
            return Ok(new { Message = "Request Completed" });
        }

        [Route("{id}")]
        public IActionResult Get(string id)
        {
            _hub.Clients.All.SendAsync("InputData", DataManager.GetData());
            return Ok(new { Message = "Request Completed..." });
        }

        [HttpGet]
        [Route("startquestionpoll")]
        public IActionResult Startquestionpoll()
        {
            _hub.Clients.All.SendAsync("startquestionpoll", 123);
            return Ok(new { Message = "startquestionpoll Request Completed..." });
        }
    }

}
