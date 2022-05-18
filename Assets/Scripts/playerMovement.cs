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

    //interactions
    public GameObject interactableIcon;
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    public GameObject Snap;
    public bool sloweddown = false;

    void Start()
    {
        // movement setup
        originalSpeed = movementSpeed;
        sprint = maxstam;
        interactableIcon.SetActive(false);
    }

    void Update()
    {
        print(sloweddown);
        if (Snap.transform.childCount > 0 && !sloweddown)
        {
            movementSpeed -= 2;
            sloweddown = true;
        }
        else if(Snap.transform.childCount < 1 && sloweddown)

        {
            movementSpeed += 2;
            sloweddown = false;

        }
        

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
        if (Input.GetKeyDown(KeyCode.LeftShift) &&( !isSprinting || sprint > 0))
        {
            movementSpeed *= speedmultiplier;
            isSprinting = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) && isSprinting && sprint > 0)
        {
            sprint -= stamdown * Time.deltaTime;
            sprintcool = 0;
        }
        if (!isSprinting && sprint < maxstam)
        {
            sprint += stamup * Time.deltaTime;
        }
        if (sprint <= 0 || (Input.GetKeyUp(KeyCode.LeftShift)) || sprintcool > 0)
        {
            movementSpeed = originalSpeed;
            sprintcool += 1 * Time.deltaTime;
            if (sprintcool >= 0.8)
            {
                isSprinting = false;
                sprintcool = 0;
            }
        }

        sprintbar.sizeDelta = new Vector2(sprint / maxstam * 100, sprintbar.sizeDelta.y);

        //interacting
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
    }
    public void OpenInteractableIcon()
    {
        interactableIcon.SetActive(true);
    }
    public void CloseInteractableIcon()
    {
        interactableIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<interactable>())
                {
                    rc.transform.GetComponent<interactable>().interact();
                    return;
                }
            }
        }
    }

}
