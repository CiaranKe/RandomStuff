package org.antipathy.bluetoothserver;

import javax.microedition.io.StreamConnection;
import java.io.IOException;
import java.io.InputStream;

/**
 * Created by Ciaran on 29/10/2014.
 */
public class ProcessThread implements Runnable
{
    private StreamConnection streamConnection;
    private static final int EXIT_CMD = -1;
    private static final int KEY_RIGHT = 1;
    private static final int KEY_LEFT = 2;

    public ProcessThread(StreamConnection connection)
    {
        this.streamConnection = connection;
    }


    @Override
    public void run()
    {
        try
        {
            InputStream inputStream = streamConnection.openInputStream();
            System.out.println("Waiting for input");

            while (true)
            {
                int command = inputStream.read();

                if(command == EXIT_CMD)
                {
                    System.out.println("Done");
                    break;
                }
                processCommand(command);
            }
        } catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    private void processCommand(int command)
    {
        System.out.println("Received command" + (command == KEY_RIGHT ? "RIGHT" : "LEFT" ) );
    }
}
