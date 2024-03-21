using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//My directives above

public class GameManager : MonoBehaviour
{
    public GameObject targetPrefab; 
    public int numberOfTargets = 5; 

    // This method now takes an ARPlane parameter to directly use the selected plane
    public void SpawnTargetsOnSelectedPlane(ARPlane selectedPlane)
    {
        if (selectedPlane == null)
        {
            Debug.Log("No plane selected");
            return;
        }

        Vector2 planeSize = selectedPlane.size;
        // Iterate over the number of targets to spawn
        for (int i = 0; i < numberOfTargets; i++)
        {
            // Calculate local positions within the plane bounds
            float localX = Random.Range(-planeSize.x / 2, planeSize.x / 2);
            float localZ = Random.Range(-planeSize.y / 2, planeSize.y / 2);
            Vector3 localPosition = new Vector3(localX, 0.1f, localZ); // Adding a slight Y offset to ensure visibility
            Vector3 worldPosition = selectedPlane.transform.TransformPoint(localPosition);

            // Instantiate the target at the calculated world space position
            Instantiate(targetPrefab, worldPosition, Quaternion.identity);
        }
    }
}
