using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public SpawnCards spawner;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        spawner.Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
