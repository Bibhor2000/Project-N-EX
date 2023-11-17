using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;
using Android.Bluetooth;
using Android.Content;
 
public class BluetoothManager : MonoBehaviour
{
    public List<BluetoothDevice> discoveredDevices = new List<BluetoothDevice>();
    public TextMeshProUGUI deviceListText;
    private BluetoothReceiver receiver;
 
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation) ||
            !Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        receiver = new BluetoothReceiver(this);
        receiver.StartDiscovery();
    }
 
    void Update()
    {
        // Update the device list text as needed (e.g., when new devices are found)
        UpdateList();
    }
 
    private void UpdateList()
    {
        deviceListText.text = "Discovered Bluetooth devices:\n";
        foreach (BluetoothDevice device in discoveredDevices)
        {
            deviceListText.text += $"Name: {device.Name}, MAC address: {device.Address}\n";
        }
    }
}
