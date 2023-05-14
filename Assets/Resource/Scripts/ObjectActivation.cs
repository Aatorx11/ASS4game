using UnityEngine;

public class ObjectActivation : MonoBehaviour
{
    // Tag of the player object
    public string playerTag = "Player";

    // Reference to the object you want to activate
    public GameObject objectToActivate;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the player tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Activate the object
            objectToActivate.SetActive(true);

            // Perform other actions as needed
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the colliding object has the player tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Deactivate the object
            objectToActivate.SetActive(false);

            // Perform other actions as needed
        }
    }
}
