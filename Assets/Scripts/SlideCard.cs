using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCard : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void OnEnable()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        //slide cards based on mouse x and y coordinates
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if (active)
        {
            if (Input.GetMouseButton(0))
            {
                transform.position = new Vector3(transform.position.x - (x / 50), transform.position.y, transform.position.z - (y / 50));
            }
        }

        //adds rigidbody and inertia to it 
        if (Input.GetMouseButtonUp(0))
        {
            active = false;
            if(transform.GetComponent<Rigidbody>()== null)
            {
                transform.gameObject.AddComponent<Rigidbody>().AddForce(new Vector3(-x, 0, -y)*150);
            }
            
        }

    }
}
