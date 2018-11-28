package com.test;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import org.java_websocket.WebSocket;
import org.java_websocket.handshake.ClientHandshake;
import org.java_websocket.server.WebSocketServer;

import java.lang.reflect.Type;
import java.net.InetSocketAddress;
import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Stack;

import static java.util.Arrays.asList;

public class Server extends WebSocketServer {
    public Server(int port) throws UnknownHostException {
        super(new InetSocketAddress( port ));
    }

    public List<String> registeredTrafficLights = new ArrayList<>();
    private WebSocket currentWebsocket;

    @Override
    public void onOpen(WebSocket webSocket, ClientHandshake clientHandshake) {
        currentWebsocket = webSocket;
        Gson g = new Gson();
        String data = g.toJson(Intersection.getInstance().lights);
        webSocket.send(data);
    }


    @Override
    public void onClose(WebSocket webSocket, int i, String s, boolean b) {

        System.out.println("close");
        registeredTrafficLights.clear();
        currentWebsocket = null;
    }

    @Override
    public void onMessage(WebSocket webSocket, String s) {
        System.out.println(s);

        Type type = new TypeToken<List<String>>() {}.getType();
        Gson g = new Gson();
        List<String> changedLights = g.fromJson(s, type);

        registeredTrafficLights.addAll(changedLights);
    }

    @Override
    public void onError(WebSocket webSocket, Exception e) {
        System.out.println(e);
    }

    public void Send(String data)
    {
        if (currentWebsocket == null)
            return;
        currentWebsocket.send(data);
    }


}
