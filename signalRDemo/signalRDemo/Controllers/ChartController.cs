using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalRDemo.DataStorage;
using signalRDemo.HubConfig;
using signalRDemo.TimerFeatures;

namespace signalRDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        /// <summary>
        /// The hub
        /// </summary>
        private IHubContext<ChartHub> _hub;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartController"/> class.
        /// </summary>
        /// <param name="hub">The hub.</param>
        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}
