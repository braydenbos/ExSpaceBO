using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{


    private Animator animator;
    //movement
    public float movementSpeed;
    private float originalSpeed;
    private float moveX;
    private float moveY;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer pickedUpSR;
    private CapsuleCollider2D playercollider;

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
    public Sprite E;
    public Sprite Square;

    //menu open
    public bool menuOpen = false;
    public GameObject menu;


    void Start()
    {
        // movement setup
        originalSpeed = movementSpeed;
        sprint = maxstam;
        interactableIcon.SetActive(false);
        playercollider = gameObject.GetComponent<CapsuleCollider2D>();
        //sprite renderer
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            // Pickup
        if (Snap.transform.childCount > 0 && !sloweddown)
        {
            pickedUpSR = Snap.transform.GetComponentInChildren<SpriteRenderer>();
            movementSpeed -= 2;
            sloweddown = true;
        }
        else if(Snap.transform.childCount < 1 && sloweddown)

        {
            movementSpeed += 2;
            sloweddown = false;
        }


        // Walking
        if (Input.GetAxis("Vertical") > 0)
        {
            moveY = 1f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            moveY = -1f;
        }
        else
        {
            moveY = 0f;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            moveX = -1f;
            spriteRenderer.flipX = true;
            playercollider.offset = new Vector2(-0.2f, playercollider.offset.y);
            if (sloweddown)
            {
                pickedUpSR.flipX = true;
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            moveX = 1f;
            spriteRenderer.flipX = false;
            playercollider.offset = new Vector2(0.2f,playercollider.offset.y);
            if (sloweddown)
            {
                pickedUpSR.flipX = false;
            }
        }
        else
        {
            moveX = 0f;
        }
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            SpriteRenderer Icon = interactableIcon.GetComponent<SpriteRenderer>();
            Icon.sprite = E;
        }
        else if (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            SpriteRenderer Icon = interactableIcon.GetComponent<SpriteRenderer>();
            Icon.sprite = Square;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += movementSpeed * Time.deltaTime * moveDir;

        // Sprinting
        if (Input.GetAxis("Sprint") > 0 &&!isSprinting )
        {
            originalSpeed = movementSpeed;
            movementSpeed *= speedmultiplier;
            isSprinting = true;
        }
        if (Input.GetAxis("Sprint") > 0 && isSprinting && sprint > 0)
        {
            sprint -= stamdown * Time.deltaTime;
            sprintcool = 0;
            animator.SetBool("sprinting", true);
        }
        else
        {
            animator.SetBool("sprinting", false);
        }
        if (!isSprinting && sprint < maxstam)
        {
            sprint += stamup * Time.deltaTime;
        }
        if (sprint <= 0 || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Joystick1Button1) || sprintcool > 0 )
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

        menu.SetActive(menuOpen);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuOpen = !menuOpen;
        }

        if (Input.GetAxis("Interact") > 0)
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
        RaycastHit2D[] hits = Physics2D.BoxCastAll(new Vector2(transform.position.x, transform.position.y - 3f), boxSize, 0, Vector2.zero);

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
