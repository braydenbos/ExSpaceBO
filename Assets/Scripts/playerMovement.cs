using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    //movement
    public float movementSpeed;
    private float originalSpeed;
    //sprinting
    private bool isSprinting = false;
    public RectTransform sprintbar;
    private float sprint;
    public float speedmultiplier;
    private float sprintcool;
    //stamina
    public float stamup;
    public float stamdown;
    public float maxstam = 20;
    void Start()
    {
        originalSpeed = movementSpeed;
        sprint = maxstam;

    }
    void Update()
    {
        print(sprint);
        // Sprinting
        if(Input.GetKeyDown(KeyCode.LeftShift) && sprint >= maxstam && !isSprinting)
        {
            movementSpeed *= speedmultiplier;
            isSprinting = true;
        }
        if(Input.GetKey(KeyCode.LeftShift) && isSprinting)
        {
            sprint -= stamdown * Time.deltaTime;
        }
        if(!isSprinting && sprint < maxstam)
        {
            sprint += stamup * Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = originalSpeed;
            isSprinting = false;
        }
        if(sprint <= 0)
        {
            movementSpeed = originalSpeed;
            sprintcool += 1 * Time.deltaTime;
            sprint = 0;
            if(sprintcool >= 2)
            {
                isSprinting = false;
                sprintcool = 0;
            }
        }
        sprintbar.sizeDelta = new Vector2(sprint/maxstam*20, sprintbar.sizeDelta.y);

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
