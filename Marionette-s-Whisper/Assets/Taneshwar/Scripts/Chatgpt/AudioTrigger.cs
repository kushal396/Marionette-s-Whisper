using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    private bool isPlaying = false;

    private bool hasTriggered = false;
    private bool isMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            PlayAudio();
        }
    }

    

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isPlaying)
            {
                isPlaying = false;
                StopAudio();
            }
        }
    }




    private void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    private void StopAudio()
    {
        audioSource.Stop();
    }
}







