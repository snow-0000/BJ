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
    public void Play()
    {
        if (twoD)
        {
            SceneManager.LoadScene(players.ToString() + "Players2D");
        }
        if (!twoD)
        {
            SceneManager.LoadScene(players.ToString() + "Players3D");
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
