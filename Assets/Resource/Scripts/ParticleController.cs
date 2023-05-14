using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float minPauseDuration = 1f;
    public float maxPauseDuration = 3f;

    private void Start()
    {
        StartCoroutine(LoopWithPause());
    }

    private IEnumerator LoopWithPause()
    {
        while (true)
        {
            // Play the particle system.
            particleSystem.Play();

            // Wait for it to finish.
            yield return new WaitForSeconds(particleSystem.main.duration);

            // Stop the particle system.
            particleSystem.Stop();

            // Generate a random pause duration.
            float pauseDuration = Random.Range(minPauseDuration, maxPauseDuration);

            // Wait for the pause duration.
            yield return new WaitForSeconds(pauseDuration);
        }
    }
}
