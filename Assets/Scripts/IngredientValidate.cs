using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientValidate : MonoBehaviour
{

    private HashSet<string> crohns;

    public GameObject infoBox;
    private TMP_Text crohnsInfo;

    private const string CrohnsPreamble = "People with Crohn's Disease can't have ";
    private const string because = " beacause ";
    private const string fiber = "it is high in fiber.";
    private const string spice = "spicy foods can trigger inflammation";
    private const string fatMeat = "fatty meat can trigger a flare up";

    private void Awake()
    {
        crohns = new HashSet<string>();
      //  crohns.Add("Chicken");
       // crohns.Add("Zucchini");
        crohns.Add("Salt");
       // crohns.Add("Pepper");
        crohns.Add("OliveOil");
        crohns.Add("Salmon");
        crohnsInfo = infoBox.GetComponent<TMP_Text>();
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
        bool result = crohns.Contains(ingredient);
        if (!result) 
        {
            string info = CrohnsPreamble + ingredient.ToLower() + because;
            if (ingredient.Equals("Broccoli") || ingredient.Equals("Cauliflower"))
            {
                info += fiber;
            }
            else if (ingredient.Equals("Steak")) {
                info += fatMeat;
            }
            else if (ingredient.Equals("Spice")) {
                info += spice;
            }
            crohnsInfo.text = info;
            StartCoroutine("displayInfo");
        }
        return result;
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

    private IEnumerator displayInfo() {
        infoBox.SetActive(true);
        yield return new WaitForSeconds(7.5f);
        infoBox.SetActive(false);
    }
}
