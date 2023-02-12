using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMainMenu : MonoBehaviour
{
    //loads main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
