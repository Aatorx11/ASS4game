using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallControl : MonoBehaviour
{
    // Assign the object to be controlled in the Unity Inspector
    public GameObject controlledObject;

    // Cache the BoxCollider2D component of the controlled object
    private BoxCollider2D controlledObjectCollider;

    // Track whether it's the first Shift key press
    private bool isFirstShiftKeyPress = true;

    private void Start()
    {
        // Get the BoxCollider2D component of the controlled object
        controlledObjectCollider = controlledObject.GetComponent<BoxCollider2D>();

        // Make sure the controlled object has the required component
        if (controlledObjectCollider == null)
        {
            Debug.LogError("Controlled object does not have a BoxCollider2D component.");
        }

        // Make sure the controlled object has at least one child
        if (controlledObject.transform.childCount == 0)
        {
            Debug.LogError("Controlled object does not have any children.");
        }
    }

    private void Update()
    {
        // Check if any side of the Shift key is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            // Ignore the first Shift key press
           {
                // Toggle the BoxCollider2D component of the controlled object
                if (controlledObjectCollider != null)
                {
                    controlledObjectCollider.enabled = !controlledObjectCollider.enabled;
                }

                // Toggle the Renderer and BoxCollider2D components of all children of the controlled object
                foreach (Transform child in controlledObject.transform)
                {
                    Renderer childRenderer = child.GetComponent<Renderer>();
                    BoxCollider2D childCollider = child.GetComponent<BoxCollider2D>();

                    if (childRenderer != null)
                    {
                        childRenderer.enabled = !childRenderer.enabled;
                    }
                    else
                    {
                        Debug.LogWarning("Child object " + child.name + " does not have a Renderer component.");
                    }

                    if (childCollider != null)
                    {
                        childCollider.enabled = !childCollider.enabled;
                    }
                    else
                    {
                        Debug.LogWarning("Child object " + child.name + " does not have a BoxCollider2D component.");
                    }
                }
            }
        }
    }
}
