using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed;
    public float length;
    private float timer;
    
    public Transform target;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != target.position.x || transform.position.y != target.position.y)
        {
            timer += 100 * Time.deltaTime;
            if (timer >= length)
            {
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(target.position.x, target.position.y, -20), speed * Time.deltaTime);
            }
        }
        else
        {
            timer = 0;
        }

    }
}
