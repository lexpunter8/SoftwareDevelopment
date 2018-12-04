package com.test;

import com.google.gson.Gson;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.List;
import java.util.concurrent.TimeUnit;


public class Main {

    public static void main(String[] args) throws IOException, InterruptedException {
        int port = 9090;
        Server server = new Server(port);
        server.start();
        System.out.println( "Server started on port: " + server.getAddress() );

        boolean testMode = false;

        BufferedReader sysin = new BufferedReader( new InputStreamReader( System.in ) );
        while ( true) {

            boolean isConnceted = server.isConnected();
            if (testMode && isConnceted)
            {
                for (TrafficLight lt :
                    Intersection.getInstance().lights) {
                    Gson gson = new Gson();
                    lt.status = "red";
                    String text = gson.toJson(lt);
                    server.Send(text);
                    TimeUnit.SECONDS.sleep(1);

                    lt.status = "orange";
                    gson = new Gson();
                    text = gson.toJson(lt);
                    server.Send(text);
                    TimeUnit.SECONDS.sleep(1);

                    lt.status = "green";
                    gson = new Gson();
                    text = gson.toJson(lt);
                    server.Send(text);
                    TimeUnit.SECONDS.sleep(1);
                }


            }

            if (!server.registeredTrafficLights.isEmpty() && !testMode){

                List<String> toGreen = Intersection.getInstance().getLightsToGreen(server.registeredTrafficLights);
                Intersection.getInstance().setToGreen(toGreen, true);
                Gson g = new Gson();
                server.Send(g.toJson(Intersection.getInstance().lights));
                g = new Gson();
                System.out.println("registered: " + g.toJson(server.registeredTrafficLights));
                server.registeredTrafficLights.removeAll(toGreen);
                TimeUnit.SECONDS.sleep(3);
                Intersection.getInstance().greenToOrange();
                g = new Gson();
                server.Send(g.toJson(Intersection.getInstance().lights));
                TimeUnit.SECONDS.sleep(3);
            }

        }

    }
}
