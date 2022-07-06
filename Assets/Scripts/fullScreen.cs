using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullScreen : MonoBehaviour
{
    private void Awake()
    {
        Screen.fullScreen = true;
        Cursor.visible = true;
    }
}
