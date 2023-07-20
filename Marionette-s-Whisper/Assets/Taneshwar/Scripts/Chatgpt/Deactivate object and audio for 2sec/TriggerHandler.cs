using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public AudioClip triggerSound;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the game object
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there is no AudioSource component, add one and set the audio clip
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = triggerSound;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger was activated by the player or another object
        if (other.CompareTag("Player"))
        {
            // Deactivate the specified game object
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }

            // Play the trigger sound for 2 seconds
            if (triggerSound != null)
            {
                audioSource.PlayOneShot(triggerSound);
            }

            // Call the method to reactivate the game object and stop the sound after 2 seconds
            StartCoroutine(ReactivateObjectAndStopSound());
        }
    }

    private System.Collections.IEnumerator ReactivateObjectAndStopSound()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        

        // Stop the trigger sound
        if (triggerSound != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
