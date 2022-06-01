using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temp : interactable
{
    public override void interact()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
