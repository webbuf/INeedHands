using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItems : MonoBehaviour
{
    /*public GameObject objectToInstantiate; // Prefab of the object to instantiate
    public GameObject targetObject; // The object to use as the reference for positioning

    private void OnCollisionEnter(Collision collision)
    {
        // Print debug information about the collision
        Debug.Log($"Collided with {collision.gameObject.name}");

        // Check if the collided object has a Rigidbody
        if (collision.rigidbody != null)
        {
            Debug.Log("Object has a Rigidbody");

            InstantiateObjectAboveTarget();
        }
    }
    private void InstantiateObjectAboveTarget()
    {
        if (objectToInstantiate != null && targetObject != null)
        {
            // Get the position of the target object
            Vector3 targetPosition = targetObject.transform.position;

            // Calculate the new position, 5 feet (1.524 meters) above the target object
            Vector3 newPosition = targetPosition + new Vector3(0, 1.524f, 0);

            // Instantiate the object at the new position
            Instantiate(objectToInstantiate, newPosition, Quaternion.identity);

            Debug.Log("Object instantiated above target!");
        }
        else
        {
            Debug.LogWarning("Object to Instantiate or Target Object is not assigned.");
        }
    }*/
    public GameObject targetObject; // The object to use as the reference for positioning
    public float heightAboveTarget = 1.524f; // Height above the target object in meters (5 feet)

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that collided has a Rigidbody
        if (collision.rigidbody != null)
        {
            // Get the GameObject that collided with this object
            GameObject collidedObject = collision.gameObject;

            // Call the method to instantiate the collided object above the target
            InstantiateObjectAboveTarget(collidedObject);
        }
    }

    private void InstantiateObjectAboveTarget(GameObject objectToInstantiate)
    {
        if (targetObject != null)
        {
            // Get the position of the target object
            Vector3 targetPosition = targetObject.transform.position;

            // Calculate the new position, heightAboveTarget meters above the target object
            Vector3 newPosition = targetPosition + new Vector3(0, heightAboveTarget, 0);

            // Instantiate a copy of the collided object at the new position
            Instantiate(objectToInstantiate, newPosition, Quaternion.identity);

            Debug.Log($"Instantiated {objectToInstantiate.name} above target!");
        }
        else
        {
            Debug.LogWarning("Target Object is not assigned.");
        }
    }

}


