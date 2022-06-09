using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteLayerChange : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject snap;
    public GameObject Enemy;
    private SpriteRenderer SREnemy;
    private SpriteRenderer srChild;
    public int minus;
    private int layer;
    private bool plus;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if(gameObject.name == "Player")
        {
            snap = GameObject.Find("Snap");
        }
        SREnemy = Enemy.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //layer to location
        if (gameObject.transform.position.y > 72 - minus)
        {
            layer = 2;
        }
        else if (gameObject.transform.position.y < 72 - minus && gameObject.transform.position.y > 46 - minus)
        {
            layer = 6;
        }
        else if (gameObject.transform.position.x < -20 && gameObject.transform.position.y > 12 - minus)
        {
            layer = 6;
        }
        else if (gameObject.transform.position.y < 46 - minus && gameObject.transform.position.y > 16.5 - minus)
        {
            layer = 5;
        }
        else if (gameObject.transform.position.y < 16.5 - minus && gameObject.transform.position.y > 9 - minus)
        {
            layer = 2;
        }
        else if (gameObject.transform.position.y < 9 - minus && gameObject.transform.position.y > 3.4 - minus)
        {
            layer = 7;
        }
        else if (gameObject.transform.position.y < 3.4 - minus && gameObject.transform.position.y > -30 - minus)
        {
            layer = 11;
        }
        else if (gameObject.transform.position.y < -30 - minus)
        {
            layer = 17;
        }
        // enemy compair player
        if (Enemy.transform.position.y > transform.position.y)
        {
            sr.sortingOrder = layer + 1;
            if (plus)
            {
                plus = false;
                SREnemy.sortingOrder =- 2;
            }
        }
        else if (Enemy.transform.position.y == transform.position.y)
        {
            sr.sortingOrder = layer;
            if (plus)
            {
                plus = false;
                SREnemy.sortingOrder =- 2;
            }
        }
        else if (Enemy.transform.position.y < transform.position.y)
        {
            sr.sortingOrder = layer - 1;
            if (!plus)
            {
                SREnemy.sortingOrder =+ 2;
                plus = true;
            }
        }
        //get child
        if (gameObject.name == "Player" && snap.transform.childCount == 1)
        {
            srChild = snap.transform.GetChild(0).GetComponent<SpriteRenderer>();
            srChild.sortingOrder = sr.sortingOrder + 1;
        }

    }
}
