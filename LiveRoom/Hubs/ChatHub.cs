using System;
using Microsoft.AspNetCore.SignalR;

namespace LiveRoom.Hubs
{
	public class ChatHub : Hub
    {
		private readonly String _botUser;
		public ChatHub()
		{
			_botUser = "MyChat Bot";
		}
		public async Task JoinRoom(UserConnection userConnection)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

			// routes "Hi guys" message to all clients in that group
			await Clients.Group(userConnection.Room).SendAsync("RecieveMessage", _botUser
				, $"{userConnection.User} just joined {userConnection.Room}");

		}

        public async Task SendMessage(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            // routes "Hi guys" message to all clients in that group
            await Clients.Group(userConnection.Room).SendAsync("RecieveMessage", userConnection.User
                , $"{userConnection.Message}");

        }
    }
}

