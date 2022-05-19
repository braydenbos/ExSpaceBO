using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class droppointGen : interactable
{
    public bool activated = false;
    private GameObject pickupobject;
    public bool alive = true;

    public override void interact()
    {
        if (!activated)
        {
            pickupobject = GameObject.Find("gas");
            pickup pickupscript = pickupobject.GetComponent<pickup>();
            if (pickupscript.pickedup)
            {
                pickupobject.transform.parent = null;
                Destroy(pickupobject);
                activated = true;
                pickupscript.pickedup = false;
            }
        }
    }
}
