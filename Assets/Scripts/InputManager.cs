using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject runtimeCanvas;

    public SpawnCards spawnCards;
    public CameraMovement cameraMovement;

    public bool active;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active)
            {
                //enable machanics
                cameraMovement.active = true;
                spawnCards.active = true;

                menuCanvas.SetActive(false);
                runtimeCanvas.SetActive(true);
                active = false;
            }
            else
            {
                //disable mechanics
                cameraMovement.active = false;
                spawnCards.active = false;

                menuCanvas.SetActive(true);
                runtimeCanvas.SetActive(false);
                active = true;
            }
        }
    }
    public void Resume()
    {
        active = false;

        //enable machanics
        cameraMovement.active = true;
        spawnCards.active = true;

        menuCanvas.SetActive(false);
        runtimeCanvas.SetActive(true);
        active = false;
 
    }
}
