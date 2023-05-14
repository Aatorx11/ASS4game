using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformFAN : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;
    public float stopTime = 5.0f; // Max stop time for the platform

    private float startTime;
    private float journeyLength;
    private float stopStartTime;
    private bool isMoving = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + endPosition;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isMoving = !isMoving;

            if (!isMoving)
            {
                // Record the time when the platform was stopped
                stopStartTime = Time.time;
            }
        }

        // Check if the platform has been stopped for more than stopTime seconds
        if (!isMoving && Time.time - stopStartTime > stopTime)
        {
            // Restart the platform
            isMoving = true;
        }

        if (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(fractionOfJourney, 1));
        }
    }
}
