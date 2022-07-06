using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    public bool trigger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Enemy")
        {
            trigger=true;
            collision.collider.transform.position += collision.collider.transform.position - new Vector3(transform.position.x, transform.position.y - 3.65f);
            transform.position += new Vector3(transform.position.x, transform.position.y- 3.65f) - collision.collider.transform.position;
        }
    }
}
