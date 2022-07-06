using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deur : interactable
{
    public int timer;
    private float doortimer;
    private GameObject doorLeft;
    private GameObject doorRight;
    public GameObject distraction;
    public GameObject TimerBar;
    public Sprite lightGreen;
    public AudioClip done;
    public arrow arrow;
    public Transform portal;
    private bool open = false;
    private float ogsize;
    private float opentimer;
    private float ogPlaceL;
    private float ogPlaceR;



    private void Start()
    {
        doorLeft = GameObject.Find("doorLeft");
        doorRight = GameObject.Find("doorRight");
        ogPlaceR = doorRight.transform.position.x;
        ogPlaceL = doorLeft.transform.position.x;
        ogsize = TimerBar.transform.localScale.x;
    }
    public override void interact()
    {
        if (doortimer == 0) GetComponent<AudioSource>().Play();
        if ( doortimer >= timer)
        {
            doortimer = timer;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lightGreen;
            open = true;
            GetComponent<AudioSource>().clip = done;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            doortimer += Time.deltaTime;
            GetComponent<AudioSource>().UnPause();
        }

    }
    private void Update()
    {
        if (distraction.GetComponent<distractable>().Switch)
        {
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = lightGreen;
            if (open && opentimer < 8)
            {
                if (opentimer == 0) 
                {
                    doorLeft.GetComponent<AudioSource>().Play();
                    arrow.Show(portal.position); 
                }
                doorLeft.transform.position = new Vector2(ogPlaceL - opentimer / 1.5f, doorLeft.transform.position.y);
                if(opentimer < 3.5)
                {
                    doorRight.transform.position = new Vector2(ogPlaceR + opentimer, doorRight.transform.position.y);
                }
                Destroy(GetComponent<EdgeCollider2D>());
                opentimer += 12 * Time.deltaTime;
            }
        }
        else if(open && opentimer > 6)
        {
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        }
        if (Input.GetAxis("Interact") == 0) GetComponent<AudioSource>().Pause();
        TimerBar.transform.localScale = new Vector2(ogsize/timer* doortimer, TimerBar.transform.localScale.y);
    }
}
