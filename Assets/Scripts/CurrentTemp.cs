using System;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections.Generic;

public class CurrentTemp : MonoBehaviour
{
    public TextMeshProUGUI temperatureText;

    // Replace with your Tomorrow.io API key
    private string apiKey = "pPxiqUN9Vs7a6jmL3MdBjhwPBXw5pEYq";
    private string location = "37.4316, 78.6569"; // Replace with the desired location

    private void Start()
    {
        GetWeatherData();
    }

    private void GetWeatherData()
    {
        string apiUrl = $"https://api.tomorrow.io/v4/timelines?location={location}&fields=temperature_2m,humidity_2m,windspeed_10m,precipitation&apikey={apiKey}";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            webRequest.SendWebRequest();

            // Wait for the request to complete (blocking call)
            while (!webRequest.isDone)
            {
                // Optionally, you can add a timeout check here to prevent infinite loop
            }

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                // Parse the JSON response
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(webRequest.downloadHandler.text);

                // Update UI with weather information
                UpdateUI(weatherData);
            }
            else
            {
                Debug.LogError($"Error: {webRequest.error}");
            }
        }
    }

    private void UpdateUI(WeatherData weatherData)
    {
        if (weatherData != null && weatherData.data.timelines.Count > 0)
        {
            var timeline = weatherData.data.timelines[0];
            var intervals = timeline.intervals;

            if (intervals.Count > 0)
            {
                var dataPoint = intervals[0].values;

                // Display temperature, humidity, wind gust, and precipitation
                temperatureText.text = $"Temperature: {dataPoint.temperature_2m}°C";
            }
        }
    }

    [Serializable]
    public class WeatherData
    {
        public TimelineWrapper data;
    }

    [Serializable]
    public class TimelineWrapper
    {
        public List<Timeline> timelines;
    }

    [Serializable]
    public class Timeline
    {
        public List<Interval> intervals;
    }

    [Serializable]
    public class Interval
    {
        public Values values;
    }

    [Serializable]
    public class Values
    {
        public float temperature_2m;
    }
}