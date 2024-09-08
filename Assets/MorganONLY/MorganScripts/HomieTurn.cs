using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomieTurn : MonoBehaviour
{

    // Public field to assign the target GameObject in the Unity Editor
    public GameObject targetObject;
    public HandMovement hand;

    // To store the original rotation
    private Quaternion originalRotation;
    // To keep track of whether the object is rotated or not
    private bool isRotated = false;

    void Start()
    {
        // Ensure the targetObject is assigned and store its original rotation
        if (targetObject != null)
        {
            originalRotation = targetObject.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned.");
        }
    }

    void Update()
    {
        // Check if the "D" key is pressed to rotate to the right
        if (Input.GetKeyDown(KeyCode.D))
        {
            hand.SwitchPosition();
            if (targetObject != null)
            {
                if (isRotated)
                {
                    // Reset to the original rotation
                    targetObject.transform.rotation = originalRotation;
                }
                else
                {
                    // Rotate 90 degrees to the right (clockwise) around the Y-axis
                    targetObject.transform.Rotate(0, 90, 0);
                }
                // Toggle the rotation state
                isRotated = !isRotated;
            }
            else
            {
                Debug.LogWarning("Target GameObject is not assigned.");
            }
        }
    }
}



