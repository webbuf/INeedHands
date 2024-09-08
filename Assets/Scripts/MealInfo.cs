using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealInfo : MonoBehaviour
{
    [SerializeField]
    private bool isSafe;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getSafe()
    {
        return isSafe;
    }
}
