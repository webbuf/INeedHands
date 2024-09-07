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
        animator.SetBool("PointerClose", Input.GetKey(KeyCode.A));
    }
}
