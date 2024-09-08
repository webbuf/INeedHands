using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{

    public VFXManager vfx;
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
        if (other.transform.gameObject.GetComponent<MealInfo>() != null)
        {
            bool pass = other.transform.gameObject.GetComponent<MealInfo>().getSafe();
            if (pass)
            {
                vfx.happyEAt();
            }
            else
            {
                vfx.badEat();
            }
            Destroy(other.transform.gameObject);
        }
    }
}
