using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteLayerChange : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject snap;
    public GameObject Enemy;
    public LineRenderer lr;
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
        if (gameObject.transform.position.y > 69 - minus)
        {
            layer = 4;
        }
        else if (gameObject.transform.position.y < 69 - minus && gameObject.transform.position.y > 46 - minus)
        {
            layer = 7;
        }
        else if (gameObject.transform.position.x < -20 && gameObject.transform.position.y > 12 - minus)
        {
            layer = 30;
        }
        else if (gameObject.transform.position.y < 46 - minus && gameObject.transform.position.y > 16.5 - minus)
        {
            layer = 27;
        }
        else if (gameObject.transform.position.y < 16.5 - minus && gameObject.transform.position.y > 8 - minus)
        {
            layer = 20;
        }
        else if (gameObject.transform.position.y < 8 - minus && gameObject.transform.position.y > 3.4 - minus)
        {
            layer = 27;
        }
        else if (gameObject.transform.position.y < 3.4 - minus && gameObject.transform.position.y > -30 - minus)
        {
            layer = 35;
        }
        else if (gameObject.transform.position.y < -30 - minus)
        {
            layer = 45;
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
