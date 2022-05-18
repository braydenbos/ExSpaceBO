using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class droppoint : interactable
{
    private bool activated = false;
    public string pickup;
    private GameObject pickupobject;
    private GameObject player;
    public bool alive = true;

    public override void interact()
    {
        pickupobject = GameObject.Find(pickup);
        pickup pickupscript = pickupobject.GetComponent<pickup>();
        if (pickupscript.pickedup)
        {
            player = GameObject.Find("player");
            playerMovement playerscript = player.GetComponent<playerMovement>();
            playerscript.sloweddown = false;
            activated = true;
            print("Poof");
            pickupobject.SetActive(false);
            pickupscript.pickedup = false;
        }
    }
}
