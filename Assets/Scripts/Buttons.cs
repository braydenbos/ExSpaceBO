using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string level;
    public GameObject player;

    public void toStart(int index)
    {
        SceneManager.LoadScene(level);
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
        SceneManager.LoadScene("World" + index);
    }
    public void escape()
    {
        playerMovement playerscript = player.GetComponent<playerMovement>();
        playerscript.menuOpen = !playerscript.menuOpen;
    }
}
