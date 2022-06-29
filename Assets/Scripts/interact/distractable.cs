using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class distractable : interactable
{
    private GameObject Enemy;
    public arrow arrow;
    private trigger trigger;
    private GameObject pickupobject;
    private GameObject droppoint;
    private GameObject outlet;
    private GameObject fdis;
    public Image edge;
    public float timerTimeT;
    public float timerTime;
    private float timer;
    private bool activated = false;
    private bool triggered = false;
    private bool tri = false;
    public bool Switch;

    private void Start()
    {
        Enemy = GameObject.Find("Enemy");
        droppoint = GameObject.Find("genarator");
        fdis = GameObject.Find("firstDistraction");
        AIDestinationSetter targets = Enemy.GetComponent<AIDestinationSetter>();
        targets.targettag = fdis.transform.GetChild(1).tag;

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
                pickupobject.GetComponent<SpriteRenderer>().sortingOrder = 24;
                pickupobject.GetComponent<SpriteRenderer>().flipX = true;
                pickupobject.transform.SetParent(outlet.transform);
                pickupobject.transform.position = new Vector2(outlet.transform.position.x + 1.8f, outlet.transform.position.y + 0.2f);
                Destroy(pickupobject.GetComponent<pickup>());
                activated = true;
                timerTimeT = 0;
            }
        }

    }
    private void Update()
    {
        AIDestinationSetter targets = Enemy.GetComponent<AIDestinationSetter>();
        if (transform.childCount == 5 && !tri)
        {
            trigger = transform.GetChild(1).gameObject.GetComponent<trigger>();
            //distraction tutoriel
            if (trigger.triggered || triggered)
            {
                triggered = true;
                if (timerTimeT <= 0)
                {
                    targets.targettag = "target";
                    triggered = false;
                    tri = true;
                    Destroy(trigger);
                    fdis.transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    timerTimeT -= Time.deltaTime;
                }
            }
            if (trigger.triggered)
            {
                arrow.Show(GameObject.Find("to").transform.position);
            }

        }
        //real distraction
        if (activated && droppoint.GetComponent<droppointGen>().activated)
        {
            timer += 1 * Time.deltaTime;
            if (timer < timerTime)
            {
                if (timer < 3) edge.color = new Color32(255, 255, 255,(byte)(255/3*(3-timer)));
                else edge.gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                Switch = true;
                targets.targettag = outlet.tag;
            }
            else
            {
                targets.targettag = "target";
                droppoint.GetComponent<droppointGen>().activated = false;
                GameObject.Find("light").GetComponent<SpriteRenderer>().color = new Color32(255,169,83,255);
                timer = 0;
            }
        }
        else
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
