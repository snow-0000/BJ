using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public SpawnCards spawner;
    // Shuffles cards if mouse clicks over collider
    void OnMouseDown()
    {
        spawner.Shuffle();
    }

}
