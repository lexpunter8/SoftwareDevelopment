package com.test;

import com.google.gson.Gson;
import org.java_websocket.WebSocket;
import org.java_websocket.handshake.ClientHandshake;
import org.java_websocket.server.WebSocketServer;
import java.net.InetSocketAddress;
import java.net.UnknownHostException;

public class Server extends WebSocketServer {
    public Server(int port) throws UnknownHostException {
        super(new InetSocketAddress( port ));
    }

    @Override
    public void onOpen(WebSocket webSocket, ClientHandshake clientHandshake) {
        System.out.println("open");
        webSocket.send("open");
    }

    @Override
    public void onClose(WebSocket webSocket, int i, String s, boolean b) {
        System.out.println("close");
    }

    @Override
    public void onMessage(WebSocket webSocket, String s) {
        System.out.println(s);
        if (s.equals("close"))
        {
            webSocket.send("close");
        } else {
            TrafficLight tl = new TrafficLight();
            tl.light = "B1";
            tl.status = "Red";
            tl.timer = 0;
            Gson g = new Gson();
            String json = g.toJson(tl);

            webSocket.send(json);
        }
    }

    @Override
    public void onError(WebSocket webSocket, Exception e) {
        System.out.println(e);
    }
}
