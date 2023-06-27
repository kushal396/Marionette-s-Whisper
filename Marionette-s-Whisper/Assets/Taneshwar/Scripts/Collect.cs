using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public GameObject collectTextObj, intText;
    public AudioSource pickupsound, a1, a2, a3, a4;
    public bool interactable;
    public static int pagescollected;
    public Text collecText;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Main Camera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Main Camera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pagescollected = pagescollected + 1;
                collecText.text = pagescollected + "/4 collected";
                collectTextObj.SetActive(true);
                pickupsound.Play();
                if (pagescollected == 1)
                {
                    a1.Play();
                }
                if (pagescollected == 2)
                {
                    a2.Play();
                }
                if (pagescollected == 3)
                {
                    a3.Play();
                }
                if (pagescollected == 4)
                {
                    a4.Play();
                }
                intText.SetActive(false);
                this.gameObject.SetActive(false);
                interactable = false;
            }
        }
    }
}
