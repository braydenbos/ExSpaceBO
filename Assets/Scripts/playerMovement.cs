using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    //movement
    public float movementSpeed;
    private float originalSpeed;
    private float moveX;
    private float moveY;

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
        // Walking
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        else
        {
            moveY = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        else
        {
            moveX = 0f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += movementSpeed * Time.deltaTime * moveDir;

        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && sprint >= maxstam && !isSprinting)
        {
            movementSpeed *= speedmultiplier;
            isSprinting = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) && isSprinting)
        {
            sprint -= stamdown * Time.deltaTime;
        }
        if (!isSprinting && sprint < maxstam)
        {
            sprint += stamup * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = originalSpeed;
            isSprinting = false;
        }
        if (sprint <= 0)
        {
            movementSpeed = originalSpeed;
            sprintcool += 1 * Time.deltaTime;
            sprint = 0;
            if (sprintcool >= 2)
            {
                isSprinting = false;
                sprintcool = 0;
            }
        }

        sprintbar.sizeDelta = new Vector2(sprint / maxstam * 20, sprintbar.sizeDelta.y);

    }
}
