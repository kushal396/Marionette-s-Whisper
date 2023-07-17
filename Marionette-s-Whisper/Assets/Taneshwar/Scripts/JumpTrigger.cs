using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource run, walk;

    void Start()
    {
        GetComponent<AudioSource>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponent<AudioSource>().enabled = false;
    }
}
