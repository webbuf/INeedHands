using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientValidate : MonoBehaviour
{

    private HashSet<string> crohns;

    private void Awake()
    {
        crohns = new HashSet<string>();
      //  crohns.Add("Chicken");
       // crohns.Add("Zucchini");
        crohns.Add("Salt");
       // crohns.Add("Pepper");
        crohns.Add("OliveOil");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Boolean validateIngredient(string ingredient) {
        return crohns.Contains(ingredient);
    }

    public Boolean validateRecipe(HashSet<string> recipe) 
    {
        foreach (string s in recipe) {
            if (!crohns.Contains(s)) return false;
        }

        foreach (string s in crohns)
        {
            if (!recipe.Contains(s)) return false;
        }

        return true;
    }
}
