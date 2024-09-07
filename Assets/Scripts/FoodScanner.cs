using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FoodScanner : MonoBehaviour
{

    private float timer;

    public IngredientValidate validate;
    public GameObject fail;
    public GameObject pass;

    private void Awake()
    {
        fail.SetActive(false);
        pass.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IngredientInfo>() != null) 
        { 
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<IngredientInfo>() != null)
        { 
            timer += Time.deltaTime;
            Debug.Log(other.gameObject.name);
            if (timer > 1)
            {
                if (other.transform.gameObject.GetComponent<IngredientInfo>() != null)
                {
                    string ingredient = other.transform.gameObject.GetComponent<IngredientInfo>().getID();
                    Boolean valid = validate.validateIngredient(ingredient);
                    if (valid)
                    {
                        StartCoroutine(TriggerLight(pass));
                    }
                    else
                    {
                        StartCoroutine(TriggerLight(fail));
                    }
                    timer = -100;
                }
            }
        }
    }

    private IEnumerator TriggerLight(GameObject light) {
        light.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        light.SetActive(false);
    }
}
