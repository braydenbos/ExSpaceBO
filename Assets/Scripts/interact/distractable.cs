using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class distractable : interactable
{
    private GameObject Enemy;
    public float timertime;
    private float timer;
    private bool activated = false;
    private GameObject pickupobject;
    private GameObject droppoint;

    public override void interact()
    {
        if (!activated)
        {
            pickupobject = GameObject.Find("to");
            pickup pickupscript = pickupobject.GetComponent<pickup>();
            if (pickupscript.pickedup)
            {
                pickupobject.transform.parent = null;
                pickupobject.transform.SetParent(transform);
                pickupobject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Destroy(pickupscript);
                activated = true;
                timer = 0;
            }
        }

    }
    private void Update()
    {
        enemy enemy = Enemy.GetComponent<enemy>();
        droppoint = GameObject.Find("genarator");
        droppointGen droppointGen = droppoint.GetComponent<droppointGen>();
        distractable distractable = GetComponent<distractable>();
        print(enemy.targettag);
        if (activated && droppointGen.activated)
        {
            print("hello");
            timer += 1 * Time.deltaTime;
            if (timer < timertime)
            {
                enemy.targettag = gameObject.tag;
            }
            else
            {
                enemy.targettag = "Player";
                activated = false;
                Destroy(distractable);
            }

        }

    }
    private void Start()
    {
        timer = timertime;
        Enemy = GameObject.Find("Enemy");
    }
}
