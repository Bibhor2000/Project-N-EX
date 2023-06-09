using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using InTheHand.Net.Bluetooth;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;

namespace InTheHand.Net.Sockets {
    public class OilTempCalc : MonoBehaviour
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
            randomNumber = Random.Range(0, 250); 
            text = GetComponent<TextMeshProUGUI> ();
            text.text = randomNumber.ToString();  
        }
    
    }
}

