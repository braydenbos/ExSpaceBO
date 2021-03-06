using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<CapsuleCollider2D>().isTrigger = true;
    }
    public abstract void interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<playerMovement>().OpenInteractableIcon();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<playerMovement>().CloseInteractableIcon();
        }
    }
}