using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteLayerChange : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject snap;
    private SpriteRenderer srChild;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        snap = GameObject.Find("Snap");
    }
    void Update()
    {
        if(snap.transform.childCount == 1)
        {
            srChild = snap.transform.GetChild(0).GetComponent<SpriteRenderer>();
            srChild.sortingOrder = sr.sortingOrder;
        }
        if (gameObject.transform.position.y > 72)
        {
            sr.sortingOrder = 1;
        }
        else if (gameObject.transform.position.y < 72 && gameObject.transform.position.y > 46)
        {
            sr.sortingOrder = 2;
        }
        else if(gameObject.transform.position.y < 46 && gameObject.transform.position.y > 16.5)
        {
            sr.sortingOrder = 5;
        }
        else if (gameObject.transform.position.x < -20 && gameObject.transform.position.y > 12)
        {
            sr.sortingOrder = 3;
        }
        else if (gameObject.transform.position.y < 16.5 && gameObject.transform.position.y > 9)
        {
            sr.sortingOrder = 1;
        }
        else if (gameObject.transform.position.y < 9 && gameObject.transform.position.y > 3.4)
        {
            sr.sortingOrder = 3;
        }
        else if (gameObject.transform.position.y < 3.4 && gameObject.transform.position.y > -30)
        {
            sr.sortingOrder = 5;
        }
        else if (gameObject.transform.position.y < -30)
        {
            sr.sortingOrder = 8;
        }



    }
}
