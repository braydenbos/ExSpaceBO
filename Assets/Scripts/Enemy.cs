using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    private Transform target;
    public string targettag = "Player";
    public string prefframe;
    void Update()
    {
        if(targettag != prefframe)
        {
            if(targettag == "Player")
            {
                speed /= 2;
    }
            else
    {
                speed *= 2;
            }
        }
        print(targettag);
        target = GameObject.FindGameObjectWithTag(targettag).GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        prefframe = targettag;
    }
}
