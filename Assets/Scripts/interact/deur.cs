using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deur : interactable
{
    public int timer = 1;
    private float doortimer;
    public GameObject door;
    public RectTransform buttonTimerBar;
    public GameObject buttonBar;
    private bool open = false;

    public void Start()
    {
        doortimer = timer;
        buttonBar.SetActive(false);
    }
    public override void interact()
    {
        buttonBar.SetActive(true);
        if ( doortimer <= 0)
        {
            doortimer = 0;
            Destroy(door);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            buttonBar.SetActive(false);
            open=true;
        }
        else
        {
            doortimer -= 1 * Time.deltaTime;
        }
    }
    private void Update()
    {
        if (Input.GetAxis("Interact") == 0 && doortimer<1 && !open)
        {
            doortimer += 1 * Time.deltaTime;
            buttonBar.SetActive(false);
        }
        print(doortimer);

        buttonTimerBar.sizeDelta = new Vector2(doortimer/timer * 100, buttonTimerBar.sizeDelta.y);

    }
}
