using Microsoft.AspNetCore.SignalR;

namespace DNetCoreMVCRazorSignalR.SignalRHubs
{
	public class ChatHub : Hub
	{
		public override Task OnConnectedAsync()
		{
			return base.OnConnectedAsync();
		}

		public async Task SendMessageAsync(string sender, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage",sender, message);
		}

		public async Task SendMessageToGroupAsync(string sender,string receiver, string message)
		{
			await Clients.Group(receiver).SendAsync("ReceiveMessage",sender, message);
		}
	}
}
