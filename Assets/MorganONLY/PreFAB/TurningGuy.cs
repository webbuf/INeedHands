using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningGuy : MonoBehaviour
{
    public GameObject turningHomie;

    // Update is called once per frame
    void Update()
    {
        do
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                // Rotate the GameObject 90 degrees to the right (clockwise) around the Y-axis
                GameObject turningHomie;

                transform.Rotate(0, 90, 0);

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Rotate the GameObject 90 degrees to the right (clockwise) around the Y-axis
                GameObject turningHomie;
                transform.Rotate(0, -90, 0);
                break;
            }

        } while (true);

    }

}
