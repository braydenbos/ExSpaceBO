using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public bool triggered = false;
    public string[] triggertags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < triggertags.Length; i++)
        {
            if (collision.CompareTag(triggertags[i]))
            {
                triggered = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < triggertags.Length; i++)
        {
            if (collision.CompareTag(triggertags[i]))
            {
                triggered = false;
            }
        }
    }
}
