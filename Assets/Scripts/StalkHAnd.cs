using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkHAnd : MonoBehaviour
{
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        /* Vector3 target = hand.transform.position - transform.position;
        target.y = 0;
        target.x = -90;
        var rotate = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 2);
        transform.rotation.y = 0; */
        transform.LookAt(hand.transform.position);
    }
}
