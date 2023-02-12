using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public Transform target;
    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if destroy go towards dying point withouth collision or gravity
        if (destroy)
        {
            if (TryGetComponent(out Rigidbody rb))
            {
                rb.useGravity = false;
            }
            transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.01f);
            if(transform.position == target.position)
            {
                Object.Destroy(transform.gameObject);
            }
        }
    }
}
