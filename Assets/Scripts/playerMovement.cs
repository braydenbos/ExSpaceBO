using Pathfinding;
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
    private bool goingRight;
    public AudioSource steps;

    //object parts
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer pickedUpSR;
    private CapsuleCollider2D playercollider;
    private Animator animator;    

    //sprinting
    private bool isSprinting = false;
    public RectTransform sprintbar;
    private Vector2 sprintbarOgSize;
    private float sprint;
    public float speedmultiplier;
    private float sprintcool;

    //stamina
    public float stamup;
    public float stamdown;
    public float maxstam;

    //interactions
    public GameObject interactableIcon;
    public GameObject Snap;
    private bool sloweddown = false;
    List<GameObject> hit = new List<GameObject>();
    public Sprite E;
    public Sprite Square;

    //menu open
    public bool menuOpen = false;
    public GameObject menu;

    void Start()
    {
        sprintbarOgSize = sprintbar.sizeDelta;
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
            if (originalSpeed == movementSpeed)
            {
                movementSpeed -= 2;
                originalSpeed = movementSpeed;
            }
            else
            {
                originalSpeed -= 2;
            }
            sloweddown = true;
        }
        else if (Snap.transform.childCount < 1 && sloweddown)

        {
            movementSpeed += 2;
            originalSpeed = movementSpeed;
            sloweddown = false;
        }

        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        if (moveX != 0 || moveY != 0)
        {
            if (moveX < 0)
            {
                goingRight = true;
            }
            else if (moveX > 0)
            {
                goingRight = false;
            }
            steps.mute = false;
            animator.SetBool("walking", true);
        }
        else
        {
            steps.mute = true;
            animator.SetBool("walking", false);
        }

        spriteRenderer.flipX = goingRight;
        playercollider.offset = new Vector2(moveX * 0.45f, playercollider.offset.y);

        if (sloweddown)
        {
            pickedUpSR.flipX = goingRight;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            interactableIcon.GetComponent<Image>().sprite = E;
        }
        else if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            interactableIcon.GetComponent<Image>().sprite = Square;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("standingAstro")) transform.position += movementSpeed * Time.deltaTime * moveDir;


        if (Input.GetAxis("Sprint") > 0 && !isSprinting)
        {
            originalSpeed = movementSpeed;
            movementSpeed *= speedmultiplier;
            isSprinting = true;
        }

        if (Input.GetAxis("Sprint") > 0 && isSprinting && sprint > 0)
        {
            steps.pitch = 1.16f;
            sprint -= stamdown * Time.deltaTime;
            sprintcool = 0;
        }

        if (sprintcool >= 0.8 && sprint < maxstam)
        {
            sprint += stamup * Time.deltaTime;
        }
        else if (sprint >= maxstam)
        {
            sprintcool = 0;
        }

        if (sprint < 0 || Input.GetAxis("Sprint") == 0 || sprintcool > 0)
        {
            steps.pitch = 0.87f;
            movementSpeed = originalSpeed;
            sprintcool += 1 * Time.deltaTime;
            isSprinting = false;
        }
        animator.SetBool("sprinting", isSprinting);

        sprintbar.sizeDelta = new Vector2(sprintbarOgSize.x / maxstam * sprint, sprintbar.sizeDelta.y);

        //menu
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
        foreach(GameObject collision in hit)
        {
            if (collision.GetComponent<interactable>())
            {
                collision.GetComponent<interactable>().interact();
                return;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {  
        hit.Remove(collision.gameObject);
    }
}
