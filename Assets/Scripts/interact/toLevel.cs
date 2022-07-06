using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toLevel : interactable
{
    public string level;
    private GameObject portal;
    public Sprite sprite;
    public AudioSource startUp;
    public AudioSource loop;
    private bool isplay = false;


    private void Start()
    {
        portal = GameObject.Find("portal");
    }
    private void Update()
    {
        trigger trigger = portal.GetComponent<trigger>();
        portal.GetComponent<SpriteRenderer>().enabled = trigger.triggered;
        if (trigger.triggered && !isplay)
        {
            startUp.Play();
            loop.Play();
            isplay = true;
        }
        else if (!trigger.triggered)
        {
            startUp.Stop();
            loop.Stop();
            isplay = false;
        }
    }
    public override void interact()
    {
        SceneManager.LoadScene(level);
    }
}
