using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRGoogleChart.Hubs
{
    public class GoogleChartHub : Hub 
    {
        public async Task AddSlidesSignalR(string toppingsJson) 
        {
            await Clients.All.SendAsync("ReceiveIdPizzaTopping", toppingsJson);
        }
    }
}
