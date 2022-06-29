using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class pickup : interactable
{
    private GameObject Snap;
    public Transform Outlet;
    public Transform genarator;
    public arrow arrow;
    public bool pickedup = false;
    public override void interact()
    {
        Snap = GameObject.Find("Snap");
        if (Snap.transform.childCount == 0)
        {
            if(gameObject.name == "to") arrow.Show(Outlet.position);
            if (gameObject.name == "gas") arrow.Show(genarator.position);
            GetComponent<CapsuleCollider2D>().enabled = false;
            transform.SetParent(Snap.transform);
            transform.position = new Vector3(Snap.transform.position.x, Snap.transform.position.y, Snap.transform.position.z);
            pickedup = true;
        }
    }
    private void Update()
    {
        if (pickedup)
        {
            if(Input.GetAxis("Drop") > 0)
            {
                GetComponent<CapsuleCollider2D>().enabled = true;
                pickedup = false;
                transform.parent = null;

            }
        }
    }
}
