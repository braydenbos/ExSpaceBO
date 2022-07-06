using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartRateUp : MonoBehaviour
{
    private GameObject heartRateMonitor;
    private trigger trigger;
    public Transform player;
    private void Awake()
    {
        heartRateMonitor = GameObject.Find("heartrate");
        trigger = GetComponent<trigger>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position,100);
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
        if(heartRateMonitor.GetComponent<Image>().sprite.name == "Healthmeter_12") GetComponent<AudioSource>().Play();
    }
}
