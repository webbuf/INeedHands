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
    public GameObject fire;

    public AudioClip yum;
    public AudioClip gross;
    public AudioClip boiling;
    public AudioSource audioSource;
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
        audioSource.PlayOneShot(yum);
    }

    public void badEat() {
        serveBad.SetActive(true);
        audioSource.PlayOneShot(gross);

    }

    public void startBoil() { 
        fire.SetActive(true);
        boil.SetActive(true);
        audioSource.PlayOneShot(boiling);

    }
}
