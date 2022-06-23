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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!shield)
            {
                SceneManager.LoadScene("mainMenu");
            }
            else
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                shield = false;
                shieldSprite.GetComponent<Image>().sprite = cracked;
            }
        }
    }
}
