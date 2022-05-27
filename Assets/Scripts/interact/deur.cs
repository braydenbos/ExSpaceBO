using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deur : interactable
{
    public int timer;
    private float doortimer;
    public GameObject door;

    public override void interact()
    {
        doortimer += 1 * Time.deltaTime;
        if( doortimer > timer)
        {
            Destroy(door);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    private void Update()
    {
        if (Input.GetAxis("Interact") == 0 && doortimer>0)
        {
            doortimer -= 1 * Time.deltaTime;
        }
        print(doortimer);
    }
}
