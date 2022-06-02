using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deur : interactable
{
    public int timer;
    private float doortimer;
    public GameObject door;
    public GameObject TimerBar;
    private bool open = false;
    private float ogsize;
    private void Start()
    {
        ogsize = TimerBar.transform.localScale.y;
    }
    public override void interact()
    {
        if ( doortimer >= timer)
        {
            doortimer = timer;
            Destroy(door);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            open = true;
        }
        else
        {
            doortimer += 1 * Time.deltaTime;
        }
    }
    private void Update()
    {
        print(doortimer);
        if (Input.GetAxis("Interact") == 0 && doortimer > 0 && !open)
        {
            doortimer -= 1 * Time.deltaTime;
        }
        TimerBar.transform.localScale = new Vector2(TimerBar.transform.localScale.x,ogsize/timer* doortimer);

    }
}
