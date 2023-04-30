using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Assign the player object in the Unity Inspector
    public Transform player;

    // Assign the background image sprite in the Unity Inspector
    public Sprite backgroundSprite;

    // Offset between the camera and the player object
    public Vector3 offset;

    private GameObject background;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player object not assigned in the Inspector.");
        }

        // Create a new GameObject for the background sprite
        background = new GameObject("Background");
        background.AddComponent<SpriteRenderer>();
        background.GetComponent<SpriteRenderer>().sprite = backgroundSprite;

        // Make the background sprite a child of the camera
        background.transform.parent = transform;

        // Update the background sprite's position and scale to fit the camera view
        Camera cam = GetComponent<Camera>();
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        background.transform.localScale = new Vector3(width / backgroundSprite.bounds.size.x, height / backgroundSprite.bounds.size.y, -9);

        // Set the background sprite's Z position to be further away from the camera
        background.transform.localPosition = new Vector3(0, 0, cam.farClipPlane * 0.5f);

        // Set the sorting layer of the background sprite to render behind other objects
        background.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
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
