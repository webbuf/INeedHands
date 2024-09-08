using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMashingEvent : MonoBehaviour
{

    public GameObject passMeal; // GameObject to activate
    public GameObject failMeal;
    public float timeLimit = 5f; // Time limit in seconds
    public int requiredPresses = 10; // Number of key presses required

    private int pressCount = 0; // Counter for key presses
    private float timer = 0f; // Timer to track elapsed time
    public GameObject UI;

    private bool enoughFood = false;
    private bool burnerOn = false;

    public RecipeHandler recipe;

    private void Update()
    {
        if (enoughFood && burnerOn)
        {
            // Check if the "F" key is pressed
            if (Input.GetKeyDown(KeyCode.F))
            {
                pressCount++;
                // Reset timer on first press
                if (pressCount == 1)
                {
                    timer = Time.time;
                }

                // Check if the required number of presses is met within the time limit
                if (pressCount >= requiredPresses && (Time.time - timer) <= timeLimit)
                {
                    ActivateTarget();
                    // Reset counter and timer after activation
                    pressCount = 0;
                    timer = 0f;
                }
            }

            // Reset if time limit exceeded
            if (Time.time - timer > timeLimit)
            {
                pressCount = 0;
                timer = 0f;
            }
        }
    }

    private void ActivateTarget()
    {
        if (passMeal != null && recipe.isRecipeValid())
        {
            passMeal.SetActive(true);
            Debug.Log("Target activated!");
            UI.SetActive(false);
        }
        else if (failMeal != null)
        {
            failMeal.SetActive(true);
            Debug.Log("Target activated!");
            UI.SetActive(false);
        }
        else
        {
            Debug.Log("No meal to instantiate!");
        }
    }

    public void Activate()
    {
        enoughFood = true;
        if (enoughFood && burnerOn) UI.SetActive(true);
    }

    public void TriggerStove()
    {
        burnerOn = !burnerOn;
        if (enoughFood && burnerOn) UI.SetActive(true);
        else UI.SetActive(false);
    }
}