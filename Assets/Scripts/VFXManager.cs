using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject makeGood;
    public GameObject makeBad;
    public GameObject serveGood;
    public GameObject serveBad;
    public GameObject boil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void happyPoof() {
        makeGood.SetActive(true);
    }

    public void badPoof() {
        makeBad.SetActive(true);
    }

    public void happyEAt() {
        serveGood.SetActive(true);
    }

    public void badEat() {
        serveBad.SetActive(true);
    }

    public void startBoil() { 
        boil.SetActive(true);
    }
}
