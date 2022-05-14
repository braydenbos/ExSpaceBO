using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class openable : interactable
{
    public Sprite open;
    public Sprite closed;

    public SpriteRenderer sr;
    private bool isopen;

    public override void interact()
    {
        if (isopen)
        {
            sr.sprite = closed;
        }
        else
        {
            sr.sprite = open;
        }
        isopen = !isopen;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }
}
