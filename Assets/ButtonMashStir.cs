using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;




public class ButtonMashStir : MonoBehaviour
{
   // public GameObject potContact;
    public GameObject UI;
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the desired object
        if (collision.gameObject.CompareTag("Spatula"))
        {
            // Ensure the popup panel is assigned
            if (UI != null)
            {
                // Activate the UI panel
                UI.SetActive(true);
                               
                    //smash button ten times in 5 seconds to stir
                
            }
            else
            {
                Debug.LogWarning("UI panel is not assigned.");
            }
        }
    }
    
}
