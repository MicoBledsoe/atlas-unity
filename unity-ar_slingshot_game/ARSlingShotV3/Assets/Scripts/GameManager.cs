using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//my directives above^

public class GameManager : MonoBehaviour
{
    public GameObject targetPrefab; // the prefab for spawning targets in the inspector
    public int numberOfTargets = 5; // the number of targets to spawn
    public static ARPlane selectedPlane; // Static variable to hold the selected plane

    // Method to spawn targets on the selected AR plane
    public void SpawnTargets()
    {
        if (selectedPlane == null) return; // Exit the method if no plane is selected

        for (int i = 0; i < numberOfTargets; i++) // Loop to instantiate the specified number of targets
        {
            // Simplified instantiation position
            Vector3 position = selectedPlane.transform.position; 
            
            // Instantiate the targetPrefab at the position on the selected plane with default rotation and as a child of the plane
            Instantiate(targetPrefab, position, Quaternion.identity, selectedPlane.transform);
        }
    }
}
