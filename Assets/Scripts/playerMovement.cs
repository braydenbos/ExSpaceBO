using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed;
    private float originalSpeed;
    private float sprint = 20;
    public float speedmultiplier;
    private bool isSprinting = false;
    public RectTransform sprintbar;
    void Start()
    {
        originalSpeed = movementSpeed;
    }
    void Update()
    {
        sprintbar.sizeDelta = new Vector2(sprint, sprintbar.sizeDelta.y);
        // Sprinting
        print(movementSpeed);
        if (Input.GetKeyDown(KeyCode.LeftShift) && sprint >= 20 && !isSprinting)
        {
            movementSpeed *= speedmultiplier;
            isSprinting = true;
        }
        if(Input.GetKey(KeyCode.LeftShift) && isSprinting)
        {
            sprint -= 10 * Time.deltaTime;
        }
        if (!isSprinting && sprint < 20)
        {
            sprint += 8 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || sprint <= 0)
        {
            movementSpeed = originalSpeed;
            isSprinting = false;
        }

        // Walking
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
