using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//My directives above

public class PlaneSelectionManager : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public GameObject startButton;
    public GameManager gameManager; 
    
    public void HideStartButton()
    {
        startButton.SetActive(false);
    }
    
    private ARPlane selectedPlane = null;

    void Awake()
    {
        startButton.SetActive(false); // Initially hides the start button
    }

    void Update()
    {
        if (selectedPlane == null && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    ARRaycastHit hit = hits[0];
                    selectedPlane = hit.trackable as ARPlane;

                    // Optionally, activate the start button
                    startButton.SetActive(true);

                    // Disable the ARPlaneManager and the visual representation of all planes
                    planeManager.enabled = false;
                    foreach (ARPlane plane in planeManager.trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }

                    // Call the GameManager to spawn targets on the selected plane
                    gameManager.SpawnTargetsOnSelectedPlane(selectedPlane);
                }
            }
        }
    }
}
