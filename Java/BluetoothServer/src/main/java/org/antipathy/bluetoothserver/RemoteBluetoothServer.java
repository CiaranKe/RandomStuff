package org.antipathy.bluetoothserver;

/**
 * Created by Ciaran on 29/10/2014.
 */
public class RemoteBluetoothServer
{
    public static void main(String[] args)
    {
        Thread waitThread = new Thread(new WaitThread());
        waitThread.start();
    }
}
