using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toLevel : interactable
{
    public int level;
    public override void interact()
    {
        SceneManager.LoadScene("World" + level);
    }
}
