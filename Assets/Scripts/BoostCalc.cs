using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using InTheHand.Net.Bluetooth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;

namespace InTheHand.Net.Sockets {
    public class BoostCalc : MonoBehaviour
    {
        float randomNumber ;
        public TextMeshProUGUI text;
        void Start()
        {
            InvokeRepeating("Calculate", 1.25f, 1.25f);
        }
    // Update is called once per frame
        void Calculate()
        {
            randomNumber = Random.Range(0, 22); 
            text = GetComponent<TextMeshProUGUI> ();
            text.text = randomNumber.ToString();  
        }
        partial class BluetoothClient
        {
            private void PlatformInitialize()
            {
            }

            IReadOnlyCollection<BluetoothDeviceInfo> PlatformDiscoverDevices(int maxDevices)
            {
                List<BluetoothDeviceInfo> devices = new List<BluetoothDeviceInfo>();
                return devices.AsReadOnly();
            }

            void PlatformConnect(BluetoothAddress address, Guid service)
            {
            }

            void PlatformClose()
            {  
            }

            bool GetAuthenticate()
            {
                return false;
            }

            void SetAuthenticate(bool value)
            {

            }

            Socket GetClient()
            {
                return null;
            }

            bool GetConnected()
            {
                return false;
            }

            bool GetEncrypt()
            {
                return false;
            }

            void SetEncrypt(bool value)
            {  
            }

        }

    }  

}
