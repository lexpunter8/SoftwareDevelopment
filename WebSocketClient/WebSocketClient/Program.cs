using System;
using WebSocket4Net;


namespace WebSocketClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebSocketClient ws = new WebSocketClient("ws://141.252.220.55:8080");
            ws.Start();
            Console.ReadKey();
        }
    }
}
