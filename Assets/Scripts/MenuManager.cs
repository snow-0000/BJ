using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    int players = 1;

    public void Players(int number)
    {
        players = number;
    }

    //load scene
    public void Play()
    {
        SceneManager.LoadScene(players.ToString() + "Players");
       
    }
    //quit game
    public void Quit()
    {
        Application.Quit();
    }
}
