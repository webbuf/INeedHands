using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float handSpeedModifier;

    [SerializeField]
    private float handSpeedModifierVertical;

    [SerializeField]
    private float handAccelMax;

    [SerializeField]
    private float handDeceleration;

    [SerializeField]
    private float speedMax;

    private float horizontal;
    private float vertical;
    private float xAccel;
    private float yAccel;
    private float xSpeed;
    private float ySpeed;

    void Awake() {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        xAccel = Mathf.Clamp(horizontal * 0.2f, -handAccelMax, handAccelMax);
        yAccel = Mathf.Clamp(vertical * 0.2f, -handAccelMax, handAccelMax);

        if (yAccel < 0) { Debug.Log(yAccel); }

        if (xAccel == 0 && xSpeed != 0)
        {
            if (xSpeed > 0)
            {
                xSpeed = Mathf.Max(0, xSpeed - handDeceleration);
            }
            else
            {
                xSpeed = Mathf.Min(0, xSpeed + handDeceleration);
            }
        }

        if (yAccel == 0 && ySpeed != 0)
        {
            if (ySpeed > 0)
            {
                ySpeed = Mathf.Max(0, ySpeed - handDeceleration);
            }
            else
            {
                ySpeed = Mathf.Min(0, ySpeed + handDeceleration);
            }
        }

        if (Input.GetButton("Fire1"))
        {
            Vector3 move = new Vector3(0, vertical, 0);
            controller.Move(move * Time.fixedDeltaTime * handSpeedModifierVertical);
        }

        else if (Input.GetButton("Fire2"))
        {
            gameObject.transform.Rotate(-horizontal, 0, 0);
        }

        else
        {
            xSpeed = Mathf.Clamp(xSpeed + xAccel, -speedMax, speedMax);
            ySpeed = Mathf.Clamp(ySpeed + yAccel, -speedMax, speedMax);
            Vector3 move = new Vector3(ySpeed, 0, -xSpeed);
            controller.Move(Vector3.ClampMagnitude(move, speedMax) * Time.fixedDeltaTime * handSpeedModifier);
        }
    }
}
