using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCard : MonoBehaviour
{
    private Vector3 startingPos;
    public float offsetX;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = new Vector3(offsetX, -0.04f+offsetY, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        transform.position = Camera.main.transform.TransformPoint(startingPos);
    }
}
