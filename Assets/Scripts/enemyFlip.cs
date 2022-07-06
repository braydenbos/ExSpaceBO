using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlip : MonoBehaviour
{
    private Animator animator;
    private Vector2 thisFrame;
    private Vector2 prefFrame;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        prefFrame = transform.position;
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
            animator.SetBool("walking",true);
            gameObject.GetComponent<AudioSource>().mute = false;   
        }
        else
        {
            animator.SetBool("walking", false);
            gameObject.GetComponent<AudioSource>().mute = true;
        }
        prefFrame = transform.position;
    }
}
