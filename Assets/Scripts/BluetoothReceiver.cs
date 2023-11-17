using UnityEngine;
using UnityEngine.Android;
using System.Collections.Generic;
using Android.Bluetooth;
using Android.Content;
using Java.Lang;

public class BluetoothReceiver : BroadcastReceiver
{
    private BluetoothManager bluetoothManager;

    public BluetoothReceiver(BluetoothManager manager)
    {
        bluetoothManager = manager;
    }

    public void StartDiscovery()
    {
        // Start Bluetooth discovery
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        currentActivity.Call("registerReceiver", this, new AndroidJavaObject("android.content.IntentFilter", BluetoothDevice.ActionFound));
    }

    public void StopDiscovery()
    {
        // Stop Bluetooth discovery
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        currentActivity.Call("unregisterReceiver", this);
    }

    public override void OnReceive(Context context, Intent intent)
    {
        string action = intent.Action;

        if (action != BluetoothDevice.ActionFound)
        {
            return;
        }

        // Get the device
        // Assuming you have a List<BluetoothDevice> instead of a ParcelableArrayList

        IList<BluetoothDevice> bluetoothDeviceList = (IList<BluetoothDevice>)intent.GetParcelableArrayListExtra("bluetoothDeviceList");

        if (bluetoothDeviceList != null)
        {
            foreach (BluetoothDevice bluetoothDevice in bluetoothDeviceList)
            {
                if (bluetoothDevice.BondState != Bond.Bonded)
            {
                if (!bluetoothManager.discoveredDevices.Contains(bluetoothDevice))
                {
                    bluetoothManager.discoveredDevices.Add(bluetoothDevice);
                }
            }   
            }
        }

    }
}
