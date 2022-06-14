using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class distractable : interactable
{
    private GameObject Enemy;
    private trigger trigger;
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
        droppoint = GameObject.Find("genarator");
        tTower = GameObject.Find("tTower");
        AIDestinationSetter targets = Enemy.GetComponent<AIDestinationSetter>();
        targets.targettag = tTower.tag;

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
                pickupobject.GetComponent<SpriteRenderer>().sortingOrder = 23;
                pickupobject.GetComponent<SpriteRenderer>().flipX = true;
                pickupobject.transform.SetParent(outlet.transform);
                pickupobject.transform.position = new Vector2(outlet.transform.position.x + 0.75f, outlet.transform.position.y);
                Destroy(pickupobject.GetComponent<pickup>());
                activated = true;
                timer = 0;
            }
        }

    }
    private void Update()
    {
        AIDestinationSetter targets = Enemy.GetComponent<AIDestinationSetter>();
        if (transform.childCount == 2)
        {
            trigger = transform.GetChild(1).gameObject.GetComponent<trigger>();
            //distraction tutoriel
            if (trigger.triggered || triggered)
            {
                triggered = true;
                if (timer <= 0)
                {
                    targets.targettag = "target";
                    triggered = true;
                    Destroy(transform.GetChild(1).gameObject);
                }
                else
                {
                    timer -= Time.deltaTime;
                }
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
            }
        }
    }
}
