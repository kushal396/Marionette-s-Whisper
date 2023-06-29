
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource run, walk;
    public float activeTime;
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run.enabled = true;
                walk.enabled = false;
            }
            else
            {
                walk.enabled = true;
                run.enabled = false;
            }
        }
        else
        {
            run.enabled = false;
            walk.enabled = false;
        }
    }
    
}
