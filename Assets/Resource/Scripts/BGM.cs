using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource audioSourceA;
    public AudioSource audioSourceB;

    private bool isSongAPlaying = true;

    private void Start()
    {
        audioSourceA.Play();
        audioSourceB.Play();
        audioSourceA.loop = true;
        audioSourceB.loop = true;
        audioSourceB.volume = 0f; // Start with songB muted
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            ToggleBGM();
        }
    }

    private void ToggleBGM()
    {
        if (isSongAPlaying)
        {
            audioSourceA.volume = 0f;
            audioSourceB.volume = 1f;
        }
        else
        {
            audioSourceA.volume = 1f;
            audioSourceB.volume = 0f;
        }

        isSongAPlaying = !isSongAPlaying;
    }
}
