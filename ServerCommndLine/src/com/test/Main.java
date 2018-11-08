package com.test;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;


public class Main {

    public static void main(String[] args) throws IOException, InterruptedException {
        int port = 9090;
        Server server = new Server(port);
        server.start();
        System.out.println( "Server started on port: " + server.getAddress() );

        BufferedReader sysin = new BufferedReader( new InputStreamReader( System.in ) );
        while ( true ) {
            String in = sysin.readLine();
            System.out.println("message: " + in);
            if( in.equals( "exit" ) ) {
                server.stop(1000);
                break;
            }
        }
    }
}
