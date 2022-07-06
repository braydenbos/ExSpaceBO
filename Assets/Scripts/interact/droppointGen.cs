using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class droppointGen : interactable
{
    public bool activated = false;
    private GameObject pickupobject;
    public Transform gasRespawn;
    public distractable distractable;
    public Transform button;
    public Transform to;
    public arrow arrow;
    private GameObject newGas;
    public bool alive = true;
    public override void interact()
    {
        if (!activated)
        {
            pickupobject = GameObject.Find("gas");
            if (pickupobject.GetComponent<pickup>().pickedup)
            {
                if (distractable.activated) arrow.Show(button.position);
                else arrow.Show(to.position);
                newGas = Instantiate(pickupobject, gasRespawn);
                newGas.transform.localScale = gasRespawn.localScale;
                newGas.name = "gas";
                newGas.GetComponent<CapsuleCollider2D>().enabled = true;
                GameObject.Find("light").GetComponent<SpriteRenderer>().color = Color.green;
                Destroy(pickupobject);
                activated = true;
            }
        }
    }
}
