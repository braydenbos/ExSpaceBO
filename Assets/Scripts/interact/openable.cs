using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class openable : interactable
{
    public Sprite open;
    public Sprite closed;
    private GameObject Enemy;
    public SpriteRenderer sr;
    public float timertime;
    private float timer;
    private bool activated = false;

    public override void interact()
    {
        activated = true;
        timer = 0;
    }
    private void Update()
    {
        enemy enemy = Enemy.GetComponent<enemy>();
        if (activated)
        {
            timer += 1 * Time.deltaTime;
        }
        if (timer < timertime)
        {
            enemy.targettag = gameObject.tag;
        }
        else
        {
            enemy.targettag = "Player";
            activated = false;
        }

    }
    private void Start()
    {
        timer = timertime;
        Enemy = GameObject.Find("Enemy");
        sr = GetComponent<SpriteRenderer>();
    }
}
