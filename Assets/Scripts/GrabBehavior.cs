using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour
{
    SphereCollider sphereCollider;
    Transform child = null;
    private bool grabbing = false;
    // Start is called before the first frame update

    private void Awake()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int fingersDown = 0;
        fingersDown += Input.GetKey(KeyCode.A) ? 1 : 0;
        fingersDown += Input.GetKey(KeyCode.W) ? 1 : 0;
        fingersDown += Input.GetKey(KeyCode.E) ? 1 : 0;
        fingersDown += Input.GetKey(KeyCode.R) ? 1 : 0;
        fingersDown += Input.GetKey(KeyCode.Space) ? 1 : 0;
        Debug.Log(fingersDown);
        if (fingersDown >= 3 && !grabbing)
        {
            grabbing = true;
            sphereCollider.enabled = true;
        }

        else if(fingersDown < 3 && grabbing){
            grabbing = false;
            sphereCollider.enabled = false;
            Debug.Log("The grabberrr");
            if (gameObject.transform.childCount > 1) {
                Rigidbody r = child.gameObject.GetComponent<Rigidbody>();
                child.gameObject.transform.SetParent(null);
                r.useGravity = true;
                r.constraints = RigidbodyConstraints.None;
                //r.velocity = gameObject.GetComponent<Rigidbody>().velocity;
                //Debug.Log(gameObject.GetComponent<Rigidbody>().velocity);
                child = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("No grab here");
        if ((other.gameObject.tag == "Grabbable" || other.gameObject.tag == "Spatula") && gameObject.transform.childCount < 2)
        {
            other.gameObject.transform.SetParent(gameObject.transform);
            child = other.gameObject.transform;
            Debug.Log("The grabbed");
            Rigidbody r = child.gameObject.GetComponent<Rigidbody>();
            r.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
