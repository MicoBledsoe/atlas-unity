using UnityEngine;
// my directives above

public class TargetBehavior : MonoBehaviour
{
    private Vector3 randomDirection; // Private var to store the random direction for movement
    public float speed = 1.0f; // Public var to set the movement speed, which is obvi adjustable in the Unity inspector

    void Start()
    {
        // Generate a random direction for movement when the game starts
        // This is done by choosing a random angle and converting it to a direction vector on a unit circle (in the XZ plane)
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad; // Converting the angle from degrees to radians
        randomDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)); // Creating the direction vector based on the angle
    }

    void Update()
    {
        // Move the GameObject in the calculated random direction every frame, adjusted by speed and time to make it frame-rate independent
        transform.Translate(randomDirection * speed * Time.deltaTime, Space.World); // Moving in the world space\
    }
}
