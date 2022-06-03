using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class distractableT : MonoBehaviour
{
    private GameObject Enemy;
    public float timertime;
    private float timer;
    private bool triggered = false;
    private GameObject tTower;

    private void Update()
    {
        Enemy = GameObject.Find("Enemy");
        tTower = GameObject.Find("tTower");
        AIDestinationSetter targets = Enemy.GetComponent<AIDestinationSetter>();
        if (!triggered)
        {
            targets.targettag = tTower.tag;
        }
        else
        {
            if(timer <= 0)
            {
                targets.targettag = "Player";
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

    }
    private void Start()
    {
        timer = timertime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered=true;
    }
}
