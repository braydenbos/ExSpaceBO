using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeRoom : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;
    void Start()
    {
        BoxCollider2D.isTrigger = true;
    }
}
