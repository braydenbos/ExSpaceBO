using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void toStart()
    {
        SceneManager.LoadScene("wiresToAndFrom");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
