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
        System.out.println("open" + webSocket.getRemoteSocketAddress());

        Gson g = new Gson();
        String json = g.toJson(lights);
        System.out.println(json);
        webSocket.send(json);
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
            Gson g = new Gson();
            String json = g.toJson(lights);
            System.out.println(json);
            webSocket.send(json);
        }
    }

    private TrafficLight CreateTrafficLight(String id, String status, int timer){
        TrafficLight light = new TrafficLight();
        light.light = id;
        light.status = status;
        light.timer = timer;
        return light;
    }

    @Override
    public void onError(WebSocket webSocket, Exception e) {
        System.out.println(e);
    }

    private TrafficLight[] lights = {
            CreateTrafficLight("A1", "red", 0),
            CreateTrafficLight("A2", "red", 0),
            CreateTrafficLight("A3", "red", 0),
            CreateTrafficLight("A4", "red", 0),
            CreateTrafficLight("A5", "green", 0),
            CreateTrafficLight("A6", "red", 0),
            CreateTrafficLight("A7", "red", 0),
            CreateTrafficLight("A8", "green", 0),
            CreateTrafficLight("A9", "red", 0),
            CreateTrafficLight("A10", "red", 0),
    };
}
