using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class imgAnimator : MonoBehaviour
{
    Image img;
    SpriteRenderer sprite;
    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        img.sprite = sprite.sprite;
    }
}
