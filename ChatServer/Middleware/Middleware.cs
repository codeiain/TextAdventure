using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using ChatServer.Handlers;
using Microsoft.AspNetCore.Http;

namespace ChatServer.Middleware
{
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private WebSocketHandler WebSocketHandler { get; set; }

        public WebSocketManagerMiddleware(RequestDelegate next, 
                                          WebSocketHandler webSocketHandler)
        {
            _next = next;
            WebSocketHandler = webSocketHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            if(!context.WebSockets.IsWebSocketRequest)
                return;
            
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await WebSocketHandler.OnConnected(socket);
            
            await Receive(socket, async(result, buffer) =>
            {
                if(result.MessageType == WebSocketMessageType.Text)
                {
                    await WebSocketHandler.ReceiveAsync(socket, result, buffer);
                    return;
                }

                else if(result.MessageType == WebSocketMessageType.Close)
                {
                    await WebSocketHandler.OnDisconnected(socket);
                    return;
                }

            });
            
            //TODO - investigate the Kestrel exception thrown when this is the last middleware
            //await _next.Invoke(context);
        }

        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while(socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                                                       cancellationToken: CancellationToken.None);

                handleMessage(result, buffer);                
            }
        }
    }
}