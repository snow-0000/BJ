using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    int players = 1;
    bool twoD = true;
    public void Players(int number)
    {
        players = number;
    }

    //gets input from button to decide wich scene to load
    public void Dimension(int number)
    {
        if (number == 2)
        {
            twoD = true;
        }
        if (number == 3)
        {
            twoD = false;
        }
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
