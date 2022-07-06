using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyKill : MonoBehaviour
{
    public bool shield = true;
    public GameObject shieldSprite;
    public Sprite cracked;
    public Animator animator;
    public Animator playerAnimator;
    public GameObject end;
    public GameObject enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (shield)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                shield = false;
                animator.enabled = true;
                spriteRenderer.color = Color.white;
            }
            else
            {
               DeathAnim();
            }
        }
    }


    private void DeathAnim()
    {
        end.SetActive(true);
        enemy.SetActive(false);
        gameObject.SetActive(false);
    }
}
