using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopChop : MonoBehaviour
{
   

    public GameObject[] objectsToDestroy; // Array of GameObjects to destroy
    public GameObject prefabToInstantiate; // Prefab to instantiate in place of destroyed objects

    public void Execute()
    {
        // Destroy specified GameObjects
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
                Debug.Log($"Destroyed {obj.name}");
            }
        }

        // Instantiate the prefab at the position of the last destroyed object, if any
        if (objectsToDestroy.Length > 0 && prefabToInstantiate != null)
        {
            // Get the position of the last destroyed object
            Vector3 lastObjectPosition = objectsToDestroy[objectsToDestroy.Length - 1].transform.position;

            // Instantiate the prefab at that position
            Instantiate(prefabToInstantiate, lastObjectPosition, Quaternion.identity);
            Debug.Log($"Instantiated {prefabToInstantiate.name} at {lastObjectPosition}");
        }
        else if (prefabToInstantiate == null)
        {
            Debug.LogWarning("Prefab to Instantiate is not assigned.");
        }
    }
}


