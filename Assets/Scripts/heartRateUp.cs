using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartRateUp : MonoBehaviour
{
    private GameObject heartRateMonitor;
    private trigger trigger;
    private void Awake()
    {
        heartRateMonitor = GameObject.Find("heartrate");
        trigger = GetComponent<trigger>();
    }
    private void Update()
    {
        if(trigger.triggered)
        {
            heartRateMonitor.GetComponent<Animator>().speed = 3;
            heartRateMonitor.GetComponent<Image>().color = new Color32(255, 105, 105, 255);
        }
        else
        {
            heartRateMonitor.GetComponent<Animator>().speed = 2;
            heartRateMonitor.GetComponent<Image>().color = new Color32(104, 255, 209, 255);
        }
    }
}