using UnityEngine;
using TMPro;
using System;
using System.Collections;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;
using Random = UnityEngine.Random;

namespace Bluetooth_Device_Scanner {
    public class BoostCalc : MonoBehaviour {
        float currentSpeed = 0f;
        float boostPressure = 0f;
        public TextMeshProUGUI text;
        private Vector3 lastPosition;
        private float lastTime;

        void Start() {
            InvokeRepeating("CalculateBoost", 1.25f, 1.25f);
            Input.location.Start(); // Start the location service
            lastTime = Time.time; // Initialize last time
        }

        void Update() {
            currentSpeed = GetSpeedFromDevice();
        }

        void CalculateBoost() {
            if (currentSpeed > 0 && currentSpeed <= 100) {
                boostPressure = currentSpeed / 5.0f;
            } else {
                boostPressure = 0;
            }
            text = GetComponent<TextMeshProUGUI> ();
            text.text = boostPressure.ToString();
        }

        float GetSpeedFromDevice() {
            if (Input.location.status == LocationServiceStatus.Running) {
                if (lastPosition != Vector3.zero && Input.location.lastData.latitude != 0) {
                    float distance = Vector3.Distance(lastPosition, new Vector3((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude));
                    float timeDifference = Time.time - lastTime;

                    float speed = distance / timeDifference;
                    float speedMph = speed * 2.23694f;

                    lastPosition = new Vector3((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude);
                    lastTime = Time.time;

                    return speedMph; // Return the calculated speed
                }
            } else {
                Input.location.Start(); // Start the location service if it's not already running
            }
            return 0f; // Return a default speed if calculations are not performed
        }
    }
}