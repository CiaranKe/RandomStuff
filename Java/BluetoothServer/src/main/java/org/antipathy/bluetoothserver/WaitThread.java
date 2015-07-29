package org.antipathy.bluetoothserver;

import javax.bluetooth.BluetoothStateException;
import javax.bluetooth.DiscoveryAgent;
import javax.bluetooth.LocalDevice;
import javax.microedition.io.Connector;
import javax.microedition.io.StreamConnection;
import javax.microedition.io.StreamConnectionNotifier;
import java.io.IOException;
import java.util.UUID;

/**
 * Created by Ciaran on 29/10/2014.
 */
public class WaitThread implements Runnable
{
    public WaitThread()
    {

    }

    @Override
    public void run()
    {
        waitforConnection();
    }

    private void waitforConnection()
    {
        LocalDevice localDevice = null;

        StreamConnectionNotifier streamConnectionNotifier;
        StreamConnection connection = null;

        try
        {
            localDevice = LocalDevice.getLocalDevice();
            localDevice.setDiscoverable(DiscoveryAgent.GIAC);

            UUID uuid = UUID.randomUUID();
            String url = "btspp://localhost:" + uuid.toString() + ";name=RemoteBluetooth";
            streamConnectionNotifier = (StreamConnectionNotifier) Connector.open(url);
            System.out.println("ConnectionString: " + url);
        }
        catch (BluetoothStateException e)
        {
            e.printStackTrace();
            return;
        }
        catch (IOException e)
        {
            e.printStackTrace();
            return;
        }
        while (true)
        {
            try
            {
                System.out.println("waiting for connection......");
                connection = streamConnectionNotifier.acceptAndOpen();
                Thread processThread = new Thread(new ProcessThread(connection));
                processThread.start();
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }
        }

    }
}
