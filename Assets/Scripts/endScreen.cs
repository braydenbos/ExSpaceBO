using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class endScreen : MonoBehaviour
{
    private float Timer;
    public Image forNow;

    void Start()
    {

    }


    void Update()
    {
        Timer -= Time.deltaTime;
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            forNow.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
