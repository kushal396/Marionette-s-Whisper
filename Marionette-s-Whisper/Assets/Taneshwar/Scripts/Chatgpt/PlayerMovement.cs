using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    private bool isMoving;

    private void Update()
    {
        // Check if the player is moving
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            if (!isMoving)
            {
                // Start playing audio sources when the player starts moving
                audioSource1.Play();
                audioSource2.Play();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                // Stop playing audio sources when the player stops moving
                audioSource1.Stop();
                audioSource2.Stop();
                isMoving = false;
            }
        }
    }
}