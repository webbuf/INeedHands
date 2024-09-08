using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecipeHandler : MonoBehaviour
{
    private HashSet<string> currentRecipe;
    public IngredientValidate validate;
    public ButtonMashingEvent cook;

    public AudioSource audioSource;
    public AudioClip oil;
    public AudioClip shaker;
    void Awake()
    {
        currentRecipe = new HashSet<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.gameObject.GetComponent<IngredientInfo>() != null) 
        {
            string id = other.transform.gameObject.GetComponent<IngredientInfo>().getID();
            currentRecipe.Add(id);
            Debug.Log(id);
            Destroy(other.transform.gameObject);
            foreach (string s in currentRecipe) {
                Debug.Log(s);
            }
            if (id.Equals("OliveOil")) {
                audioSource.PlayOneShot(oil);
            }
            else
            {
                if (id.Equals("Salt") || id.Equals("Pepper") || id.Equals("Spice")) {
                    audioSource.PlayOneShot(shaker);
                }
            }
        }

        if (currentRecipe.Count == 3)
        {
            cook.Activate();
        }
    }

    public bool isRecipeValid() {
        return validate.validateRecipe(currentRecipe);
    }

    public int getRecipeCount() {
        return currentRecipe.Count;
    }
}
