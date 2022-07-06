using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    public bool trigger;
    public AIPath destination;
    private float timer;
    public float stunTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Enemy")
        {
            trigger=true;
            collision.collider.transform.position += collision.collider.transform.position - new Vector3(transform.position.x, transform.position.y - 3.65f);
        }
    }
    private void Update()
    {
        if (trigger && timer < stunTime) timer += Time.deltaTime;
        else if (timer >= stunTime)
        {
            trigger = false;
            timer = 0;
        }
        destination.canMove = !trigger;
    }
}
