using System;
using WebSocket4Net;


namespace WebSocketClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebSocketClient ws = new WebSocketClient("ws://127.0.0.1:9090");
            ws.Start();
        }
    }
}
