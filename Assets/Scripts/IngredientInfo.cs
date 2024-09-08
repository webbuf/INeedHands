using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInfo : MonoBehaviour
{

    [SerializeField]
    private string ingredientId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getID() {
        return ingredientId;
    }

    public string setID(string id) {
        ingredientId = id;
    }
}  
