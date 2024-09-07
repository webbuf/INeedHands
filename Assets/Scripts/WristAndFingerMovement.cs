using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristAndFingerMovement : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("PointerCurl", Input.GetKey(KeyCode.R));
        animator.SetBool("ThumbCurl", Input.GetKey(KeyCode.Space));
        animator.SetBool("MiddleCurl", Input.GetKey(KeyCode.E));
        animator.SetBool("RingCurl", Input.GetKey(KeyCode.W));
        animator.SetBool("PinkyCurl", Input.GetKey(KeyCode.A));
    }
}
