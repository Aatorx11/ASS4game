using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Assign the player object in the Unity Inspector
    public Transform player;

    // Assign the background image sprite in the Unity Inspector


    // Offset between the camera and the player object
    public Vector3 offset;

 

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player object not assigned in the Inspector.");
        }

     

      

        // Update the background sprite's position and scale to fit the camera view
        Camera cam = GetComponent<Camera>();
       


    }

    private void LateUpdate()
    {
        // Check if the player object is assigned
        if (player != null)
        {
            // Update the camera position to follow the player, maintaining the offset
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
    }
}
