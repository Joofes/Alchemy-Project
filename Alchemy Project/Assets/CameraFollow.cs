using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;  // Reference to the player's transform
    public float smoothness = 0.5f;     // How smoothly the camera follows the player

    private void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the new position for the camera using Lerp
            Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        }
    }
}