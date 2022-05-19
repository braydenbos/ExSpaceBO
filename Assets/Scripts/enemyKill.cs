using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                gameObject.SetActive(false);
            }
            else
            {
                print("hallo");
                shield = false;
            }
        }
    }
}
