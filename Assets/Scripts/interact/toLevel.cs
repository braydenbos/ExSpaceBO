using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toLevel : interactable
{
    public string level;
    private GameObject portal;
    public Sprite sprite;


    private void Start()
    {
        portal = GameObject.Find("portal");
    }
    private void Update()
    {
        trigger trigger = portal.GetComponent<trigger>();
        portal.GetComponent<SpriteRenderer>().enabled = trigger.triggered;
    }
    public override void interact()
    {
        SceneManager.LoadScene(level);
    }
}
