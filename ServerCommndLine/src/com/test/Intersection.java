package com.test;

import java.util.*;

public class Intersection {
    private Intersection(){

    }

    private static Intersection instance = new Intersection();

    public static Intersection getInstance(){
        return instance;
    }

    public List<TrafficLight> lights = Arrays.asList(
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

    private TrafficLight CreateTrafficLight(String id, String status, int timer){
        TrafficLight light = new TrafficLight();
        light.light = id;
        light.status = status;
        light.timer = timer;
        return light;
    }

    public void setToGreen(List<String> lightIds, boolean othersToRed)
    {
        for (TrafficLight light:
             lights) {
            if (lightIds.contains(light.light))
            {
                light.status = "green";
            }
            else if (othersToRed){
                light.status = "red";
            }
        }
    }

    public void setToGreen(String lightId, boolean othersToRed)
    {
        for (TrafficLight light:
                lights) {
            if (light.light.equalsIgnoreCase(lightId))
            {
                light.status = "green";
            }
            else if (othersToRed){
                light.status = "red";
            }
        }
    }

    private Map<String, List<String>> ableWith = new HashMap<String, List<String>>(){{
       put("A1", Arrays.asList("A2", "A3", "A4", "A8", "A9", "A10", "E1", "D1"));
       put("A2", Arrays.asList("A1", "A3", "A4", "A6", "D1"));
       put("A3", Arrays.asList("A1", "A2", "A4", "A8", "E1", "D1"));
       put("A4", Arrays.asList("A1", "A2", "A3", "A7", "A8", "A9", "A10", "E1"));
       put("A5", Arrays.asList("A4", "A8", "A9", "A10", "E1", "D1"));
       put("A6", Arrays.asList("A1", "A2", "A7", "A8"));
       put("A7", Arrays.asList("A4", "A6", "A8", "D1"));
       put("A8", Arrays.asList("A1", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "D1"));
       put("A9", Arrays.asList("A1", "A4", "A5", "A8", "E1", "D1"));
       put("A10", Arrays.asList("A1", "A4", "A5", "A8", "E1", "D1"));
       put("B1", Arrays.asList(""));
       put("B2", Arrays.asList(""));
       put("B3", Arrays.asList(""));
       put("C1.1", Arrays.asList(""));
       put("C1.2", Arrays.asList(""));
       put("C2.1", Arrays.asList(""));
       put("C2.2", Arrays.asList(""));
       put("C3.1", Arrays.asList(""));
       put("C3.2", Arrays.asList(""));
       put("E1", Arrays.asList("A1", "A3", "A4", "A5", "A9", "A10", "D1"));
       put("D1", Arrays.asList("A1", "A2", "A3", "A5", "A6", "A7", "A8", "A9", "A10", "E1"));

    }};

    public List<String> getLightsToGreen(List<String> registeredLights){
        List<String> lightsToGreen = new ArrayList<>();
        for (String l :
                registeredLights) {
            if (lightsToGreen.isEmpty())
            {
                lightsToGreen.add(l);
                continue;
            }
            List<String> optionsForLight = ableWith.get(l);
            boolean canAdded = optionsForLight.containsAll(lightsToGreen);
            if (canAdded){
                lightsToGreen.add(l);
            }
        }
        return lightsToGreen;
    }

    public void greenToOrange(){
        for (TrafficLight light:
                lights) {
            if (light.status.equalsIgnoreCase("green"))
            {
                light.status = "orange";
            }
        }
    }

    public void alltoRed(){
        for (TrafficLight light:
                lights) {
            light.status = "red";
        }
    }
}
