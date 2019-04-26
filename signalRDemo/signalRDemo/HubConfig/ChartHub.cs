using Microsoft.AspNetCore.SignalR;
using signalRDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace signalRDemo.HubConfig
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.SignalR.Hub" />
    public class ChartHub : Hub
    {
        /// <summary>
        /// Broadcasts the chart data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public async Task BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
