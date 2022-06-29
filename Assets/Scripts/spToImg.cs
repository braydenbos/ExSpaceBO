using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spToImg : MonoBehaviour
{
    void Update()
    {
        GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
