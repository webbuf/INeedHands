using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomieTurn : MonoBehaviour
{
    // Start is called before the first frame update
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
