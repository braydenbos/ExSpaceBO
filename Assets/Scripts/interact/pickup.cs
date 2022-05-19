using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class pickup : interactable
{
    private GameObject Snap;
    public bool pickedup = false;
    public override void interact()
    {
        Snap = GameObject.Find("Snap");
        if (Snap.transform.childCount == 0)
        {
            transform.SetParent(Snap.transform);
            transform.position = new Vector3(Snap.transform.position.x, Snap.transform.position.y, Snap.transform.position.z);
            pickedup = true;

        }
    }
}
