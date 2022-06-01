using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deur : interactable
{
    public int timer = 1;
    private float doortimer;
    public GameObject door;
    public GameObject buttonBar;
    private bool open = false;
    private float ogsize;

    public void Start()
    {
        ogsize = buttonBar.transform.localScale.y;
    }
    public override void interact()
    {
        if ( doortimer >= timer)
        {
            doortimer = timer;
            Destroy(door);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            open=true;
        }
        else
        {
            doortimer += 1 * Time.deltaTime;
        }
    }
    private void Update()
    {
        if (Input.GetAxis("Interact") == 0 && doortimer > 0 && !open)
        {
            doortimer -= 1 * Time.deltaTime;
        }


        buttonBar.transform.localScale = new Vector2(buttonBar.transform.localScale.x , doortimer / timer * ogsize);

    }
}
