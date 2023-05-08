using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        randomNumber = Random.Range(0, 30); 
        text = GetComponent<TextMeshProUGUI> ();
        text.text = randomNumber.ToString();  
    }
    
}