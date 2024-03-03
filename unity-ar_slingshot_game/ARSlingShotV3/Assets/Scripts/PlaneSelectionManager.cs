using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//my directives above^

public class PlaneSelectionManager : MonoBehaviour 
{
    public ARRaycastManager raycastManager; // the ARRaycastManager component
    public ARPlaneManager planeManager; //the ARPlaneManager component
    public GameObject startButton; // UI button GameObject

    private static bool planeSelected = false; // Static boolean to keep track if a plane has been selected

    void Awake() // Awake is called when the script instance is being loaded
    {
        startButton.SetActive(false); // Initially hide the start button
    }

    void Update() // Update is called once per frame
    {
        if (!planeSelected && Input.touchCount > 0) // Checking to see if no plane is selected and there is at least one touch
        {
            Touch touch = Input.GetTouch(0); // Get the first touch
            if (touch.phase == TouchPhase.Began) // Check if the touch phase is at the beginning
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>(); // Create a new list to store raycast hits
                // Perform a raycast from the touch position and add hits to the list
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    ARRaycastHit hit = hits[0]; // Assuming the first hit is the desired one
                    ARPlane selectedPlane = hit.trackable as ARPlane; // Cast the hit trackable to ARPlane

                    planeSelected = true; // Mark as selected

                    foreach (var plane in planeManager.trackables) // Iterate through all trackable planes
                    {
                        if (plane != selectedPlane) // Check if the current plane is not the selected plane
                        {
                            plane.gameObject.SetActive(false); // Disable the plane's GameObject
                            // Destroy(plane.gameObject); // Alternatively, to destroy the plane
                        }
                    }

                    startButton.SetActive(true); // Show the start button
                }
            }
        }
    }
}
