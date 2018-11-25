<<<<<<< HEAD
package com.test;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import org.java_websocket.WebSocket;
import org.java_websocket.handshake.ClientHandshake;
import org.java_websocket.server.WebSocketServer;

import java.lang.reflect.Type;
import java.net.InetSocketAddress;
import java.net.UnknownHostException;
import java.util.Arrays;
import java.util.List;

import static java.util.Arrays.asList;

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
        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        Type type = new TypeToken<List<String>>() {}.getType();
        Gson g = new Gson();
        List<String> changedLights = g.fromJson(s, type);

        for (TrafficLight light: lights)
        {
            if (changedLights.contains(light.light)) {
                light.status = "green";
            }
        }


        g = new Gson();
        String json = g.toJson(lights);
        System.out.println(json);
        webSocket.send(json);
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

    private List<TrafficLight> lights = Arrays.asList(
            CreateTrafficLight("A1", "red", 0),
            CreateTrafficLight("A2", "red", 0),
            CreateTrafficLight("A3", "red", 0),
            CreateTrafficLight("A4", "red", 0),
            CreateTrafficLight("A5", "red", 0),
            CreateTrafficLight("A6", "red", 0),
            CreateTrafficLight("A7", "red", 0),
            CreateTrafficLight("A8", "red", 0),
            CreateTrafficLight("A9", "red", 0),
            CreateTrafficLight("A10", "red", 0)
            );

}
=======
package com.test;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import org.java_websocket.WebSocket;
import org.java_websocket.handshake.ClientHandshake;
import org.java_websocket.server.WebSocketServer;

import java.lang.reflect.Type;
import java.net.InetSocketAddress;
import java.net.UnknownHostException;
import java.util.Arrays;
import java.util.List;

import static java.util.Arrays.asList;

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
        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        Type type = new TypeToken<List<String>>() {}.getType();
        Gson g = new Gson();
        List<String> changedLights = g.fromJson(s, type);

        for (TrafficLight light: lights)
        {
            if (changedLights.contains(light.light)) {
                light.status = "green";
            }
        }


        g = new Gson();
        String json = g.toJson(lights);
        System.out.println(json);
        webSocket.send(json);
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

    private List<TrafficLight> lights = Arrays.asList(
            CreateTrafficLight("A1", "red", 0),
            CreateTrafficLight("A2", "red", 0),
            CreateTrafficLight("A3", "red", 0),
            CreateTrafficLight("A4", "red", 0),
            CreateTrafficLight("A5", "red", 0),
            CreateTrafficLight("A6", "red", 0),
            CreateTrafficLight("A7", "red", 0),
            CreateTrafficLight("A8", "red", 0),
            CreateTrafficLight("A9", "red", 0),
            CreateTrafficLight("A10", "red", 0)
            );

}
>>>>>>> 04b101eca450f9fc4a90d2653ee78f5b943cbd5e
