using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool active;
    public float speed;
    void Update()
    {
        if (active)
        {
            //Get mouse input and apply rotation if not outside bounds
            Vector3 rotation = transform.localEulerAngles;
            transform.localEulerAngles = new Vector3(rotation.x, rotation.y, 0);
            float x = Input.GetAxis("Mouse X");

            x = x * speed;

            if (Input.GetMouseButton(1))
            {
                //if (rotation.y < 240 & rotation.y > 100)
                //{
                //    transform.Rotate(new Vector3(0, x, 0), Space.Self);
                //}

                if (x > 0 & rotation.y < 240)
                {
                    transform.Rotate(new Vector3(0, x, 0), Space.Self);
                }
                if (x < 0 & rotation.y > 100)
                {
                    transform.Rotate(new Vector3(0, x, 0), Space.Self);
                }
            }
        }
       
    }
       
    
}

