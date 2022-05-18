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
        transform.SetParent(Snap.transform);
        transform.position = new Vector3(Snap.transform.position.x, Snap.transform.position.y, Snap.transform.position.z);
        pickedup = true;
    }
    private void Update()
    {

    }
    private void Start()
    {
        Snap = GameObject.Find("Snap");
    }
}
