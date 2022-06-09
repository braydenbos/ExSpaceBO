using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class distractable : interactable
{
    private GameObject Enemy;
    private GameObject Player;
    private GameObject pickupobject;
    private GameObject droppoint;
    private GameObject outlet;
    private GameObject tTower;
    public float timertimeT;
    public float timertime;
    private float timer;
    private bool activated = false;
    private bool triggered = false;
    public bool Switch;

    private void Start()
    {
        timer = timertimeT;
        Enemy = GameObject.Find("Enemy");
        Player = GameObject.Find("Player");
        droppoint = GameObject.Find("genarator");
        tTower = GameObject.Find("tTower");
    }
    public override void interact()
    {
        if (!activated)
        {
            pickupobject = GameObject.Find("to");
            if (pickupobject.GetComponent<pickup>().pickedup)
            {
                outlet = GameObject.Find("Outlet");
                pickupobject.transform.parent = null;
                pickupobject.GetComponent<SpriteRenderer>().sortingOrder = 4;
                pickupobject.GetComponent<SpriteRenderer>().flipX = true;
                pickupobject.transform.SetParent(outlet.transform);
                pickupobject.transform.position = new Vector2(1.55f, outlet.transform.position.y);
                Destroy(pickupobject.GetComponent<pickup>());
                activated = true;
                timer = 0;
            }
        }

    }
    private void Update()
    {
        AIDestinationSetter targets = Enemy.GetComponent<AIDestinationSetter>();
        //distraction tutoriel
        if (Player.transform.position.y > -30)
        {
            triggered = true;
        }
        if (!triggered)
        {
            targets.targettag = tTower.tag;
        }
        else
        {
            if (timer <= 0)
            {
                targets.targettag = "target";
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        //real distraction
        if (activated && droppoint.GetComponent<droppointGen>().activated)
        {
            timer += 1 * Time.deltaTime;
            if (timer < timertime)
            {
                Switch = true;
                targets.targettag = outlet.tag;
            }
            else
            {
                targets.targettag = "target";
                activated = false;
                Destroy(GetComponent<distractable>());
            }
        }
    }
}
