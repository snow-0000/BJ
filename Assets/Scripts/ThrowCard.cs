using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCard : MonoBehaviour
{
    private Vector3 startingPos;
    private bool active;
    public float force;

    private void Awake()
    {
        startingPos = new Vector3(0, 0, 0.25f);
        active = true;
    }
    private void Update()
    {
        if (active)
        {
            transform.parent.LookAt(Camera.main.transform);
            transform.parent.eulerAngles = new Vector3(0, transform.parent.eulerAngles.y, 0);
            transform.parent.position = Camera.main.transform.TransformPoint(startingPos);
        }

    }
    private void OnMouseDown()
    {
        active = false;
        transform.parent.gameObject.AddComponent<Rigidbody>().AddRelativeForce(Vector3.back * force, ForceMode.Force);
    }
}
