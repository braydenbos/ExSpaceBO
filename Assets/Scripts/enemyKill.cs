using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyKill : MonoBehaviour
{
    public bool shield = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!shield)
            {
                print("doei");
                SceneManager.LoadScene("mainMenu");
            }
            else
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                print("hallo");
                shield = false;
                spriteRenderer.color = Color.white;
            }
        }
    }
}
