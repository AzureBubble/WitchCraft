using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject developerImage;

    public void LoadNewGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void LoadGame()
    {
    }

    public void ShowDeveloper()
    {
        mainMenu.SetActive(false);
        developerImage.SetActive(true);
    }

    public void GoBackMenu()
    {
        mainMenu.SetActive(true);
        developerImage.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}