using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

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

    private bool rotated;
    private Vector3 kitchenPosition;
    private Vector3 pantryPosition;

    Transform rotationTarget;

    void Awake() {
        controller = gameObject.GetComponent<CharacterController>();
        kitchenPosition = new Vector3(0.813f, 1.484f, 1.305f);
        pantryPosition = new Vector3(-1.347f, 1.465f, -1.319f);
        rotationTarget = transform.GetChild(0);
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
            rotationTarget.Rotate(-horizontal, 0, 0);
        }

        else
        {
            xSpeed = Mathf.Clamp(xSpeed + xAccel, -speedMax, speedMax);
            ySpeed = Mathf.Clamp(ySpeed + yAccel, -speedMax, speedMax);
            Vector3 move;
            if (!rotated)
            {
                move = new Vector3(ySpeed, 0, -xSpeed);
            }
            else {
                move = new Vector3(-xSpeed, 0, -ySpeed);
            }
            controller.Move(Vector3.ClampMagnitude(move, speedMax) * Time.fixedDeltaTime * handSpeedModifier);
        }
    }

    public void SwitchPosition() {
        controller.enabled = false;
        if (rotated)
        {
            transform.position = kitchenPosition;
            transform.Rotate(0, -90, 0);
        }
        else
        {
            transform.position = pantryPosition;
            transform.Rotate(0, 90, 0);
        }
        controller.enabled = true;
        rotated = !rotated;
    }
}
