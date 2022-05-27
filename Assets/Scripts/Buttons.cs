using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public GameObject player;

    public void toStart()
    {
        SceneManager.LoadScene("wiresToAndFrom");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void Options()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void restart(int index)
    {
        SceneManager.LoadScene("World"+ index);
    }
    public void escape()
    {
        playerMovement playerscript = player.GetComponent<playerMovement>();
        playerscript.menuOpen = !playerscript.menuOpen;
    }
}
