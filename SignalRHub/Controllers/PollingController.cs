using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PollingController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;

        public PollingController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Request Completed..." });
        }

        [HttpGet]
        [Route("StartQuestionPoll/{questionId}")]
        public IActionResult StartQuestionPoll(int questionId)
        {
            _hub.Clients.All.SendAsync("startquestionpoll", questionId);
            return Ok(new { Message = "Request Completed..." });
        }

        //[HttpGet]
        //[Route("endquestionpolls/{questionId}")]
        //public IActionResult endquestionpoll(int questionId)
        //{
        //    _hub.Clients.All.SendAsync("endquestionpoll", questionId);
        //    return Ok(new { Message = "Request Completed..." });
        //}

        [HttpGet]
        [Route("endpresentation/{pollId}")]
        public IActionResult endpresentation(int pollId)
        {
            _hub.Clients.All.SendAsync("endpresentation", pollId);
            return Ok(new { Message = "Request Completed..." });
        }


        [HttpPost]
        [Route("submitanswer")]
        public IActionResult submitanswer([FromBody]  USERANSWER userAnswer)
        {
            _hub.Clients.All.SendAsync("submitanswer", userAnswer);
            return Ok(new { Message = "Request Completed..." });
        }
        

         [HttpPost]
        [Route("submitpollresult")]
        public IActionResult submitpollresult([FromBody]  PolledQuestion question)
        {
            _hub.Clients.All.SendAsync("submitpollresult", question);
            return Ok(new { Message = "Request Completed..." });
        }

        [HttpGet]
        [Route("participantjoined/{userId}")]
        public IActionResult participantjoined(int userId)
        {
            _hub.Clients.All.SendAsync("participantjoined", userId);
            return Ok(new { Message = "Request Completed..." });
        }
        [HttpGet]
        [Route("participantleft/{userId}")]
        public IActionResult participantleft(int userId)
        {
            _hub.Clients.All.SendAsync("participantleft", userId);
            return Ok(new { Message = "Request Completed..." });
        }
    }
}
