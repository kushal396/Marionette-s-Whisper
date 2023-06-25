using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFlashlight : MonoBehaviour
{
    public Animator flashlightanim;
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                flashlightanim.ResetTrigger("walk");
                flashlightanim.SetTrigger("run");

            }
            else
            {
                flashlightanim.ResetTrigger("run");
                flashlightanim.SetTrigger("walk");
            }
        }
    }
}