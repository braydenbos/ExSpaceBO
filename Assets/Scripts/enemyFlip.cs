using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlip : MonoBehaviour
{
    private float thisFrameX;
    private float prefFrameX;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        prefFrameX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        thisFrameX = transform.position.x;
        if(thisFrameX < prefFrameX)
        {
            spriteRenderer.flipX = true;
        } 
        else if(thisFrameX > prefFrameX)
        {
            spriteRenderer.flipX = false;
        }
        prefFrameX = transform.position.x;
    }
}
