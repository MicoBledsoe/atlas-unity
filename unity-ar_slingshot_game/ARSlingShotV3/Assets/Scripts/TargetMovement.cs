using UnityEngine;
//My directives above

public class TargetMovement : MonoBehaviour
{
    private Vector2 planeSize;
    private Vector3 planeCenter;

    public void Initialize(Vector2 size, Vector3 center)
    {
        planeSize = size;
        planeCenter = center;
    }

    void Update()
    {
        // Just ensures that the target stays within the initial bounds of the plane

        Vector3 localPos = transform.localPosition;
        localPos.x += Random.Range(-0.1f, 0.1f); // Randomly adjust position
        localPos.z += Random.Range(-0.1f, 0.1f); // Randomly adjust position

        // Clamp position to ensure it remains within the plane bounds
        localPos.x = Mathf.Clamp(localPos.x, -planeSize.x / 2, planeSize.x / 2);
        localPos.z = Mathf.Clamp(localPos.z, -planeSize.y / 2, planeSize.y / 2);

        transform.localPosition = localPos; // Apply the clamped position
    }
}
