using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Bluetooth_Device_Scanner {
    public class OilPressCalc : MonoBehaviour
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
            randomNumber = Random.Range(25, 60); 
            text = GetComponent<TextMeshProUGUI> ();
            text.text = randomNumber.ToString();  
        }
    
    }
}