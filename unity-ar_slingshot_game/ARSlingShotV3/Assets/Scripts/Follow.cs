using UnityEngine;
//My directives above

public class Follow : MonoBehaviour
{
    public Camera cameraToFollow; // the AR Camera here
    public float distanceFromCamera = 2.0f; // How far in front of the cam the object should be
    public float verticalOffset = -0.5f; // Vertical offset from the camera's center

    void Update()
    {
        if (cameraToFollow != null)
        {
            // Calculate the new position in front of the camera
            Vector3 newPosition = cameraToFollow.transform.position + cameraToFollow.transform.forward * distanceFromCamera;

            // Adjust the position lower relative to the camera
            newPosition += cameraToFollow.transform.up * verticalOffset;

            // Update the object's position
            transform.position = newPosition;
        }
    }
}
