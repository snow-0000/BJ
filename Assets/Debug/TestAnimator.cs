using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    public bool go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            GetComponent<Animator>().SetBool("lose",true);
        }
        else
        {
            GetComponent<Animator>().SetBool("lose", false);
        }
        go = false;
    }
}
