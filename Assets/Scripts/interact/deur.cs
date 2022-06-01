using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deur : interactable
{
    public int timer;
    private float doortimer;
    public GameObject door;
    public RectTransform buttonTimerBar;
    public GameObject buttonBar;

    public void Start()
    {
        buttonBar.SetActive(false);
    }
    public override void interact()
    {
        doortimer += 1 * Time.deltaTime;
        buttonBar.SetActive(true);
        if ( doortimer > timer)
        {
            Destroy(door);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(buttonBar);
        }
    }
    private void Update()
    {
        if (Input.GetAxis("Interact") == 0 && doortimer>0)
        {
            
            
            doortimer -= 1 * Time.deltaTime;
        }
        print(doortimer);

        buttonTimerBar.sizeDelta = new Vector2(timer / (doortimer + 1) * 20, buttonTimerBar.sizeDelta.y);

    }
}
