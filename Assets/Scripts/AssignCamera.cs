using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AssignCamera : MonoBehaviour
{
    // assign camera too world canvas
    void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
