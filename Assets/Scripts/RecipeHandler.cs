using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeHandler : MonoBehaviour
{
    HashSet<string> currentRecipe;

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
            currentRecipe.Add(other.transform.gameObject.GetComponent<IngredientInfo>().getID());
            Destroy(other.transform.gameObject);
            foreach (string s in currentRecipe) {
                Debug.Log(s);
            }
        }
    }
}
