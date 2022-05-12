using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, movementSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementSpeed,0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -movementSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movementSpeed, 0, 0) * Time.deltaTime;
        }

    }
}
