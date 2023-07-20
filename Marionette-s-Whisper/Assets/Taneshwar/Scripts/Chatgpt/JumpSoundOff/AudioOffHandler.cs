using UnityEngine;

public class AudioOffHandler : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    private bool audioOff = false;

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Turn off both audio sources
            audioSource1.Stop();
            audioSource2.Stop();

            // Set the audioOff flag to true
            audioOff = true;

            // Call the method to turn on the audio sources after 2 seconds
            StartCoroutine(TurnOnAudioSources());
        }
    }

    private System.Collections.IEnumerator TurnOnAudioSources()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Turn on both audio sources
        if (audioOff)
        {
            audioSource1.Play();
            audioSource2.Play();
            audioOff = false;
        }
    }
}
