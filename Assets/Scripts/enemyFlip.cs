using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlip : MonoBehaviour
{
    public Vector2 thisFrame;
    public Vector2 prefFrame;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        prefFrame.x = transform.position.x;
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        thisFrame = transform.position;
        if(thisFrame.x < prefFrame.x)
        {
            spriteRenderer.flipX = true;
        } 
        else if(thisFrame.x > prefFrame.x)
        {
            spriteRenderer.flipX = false;
        }
        if(thisFrame != prefFrame)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        prefFrame = thisFrame;
    }
}
