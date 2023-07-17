using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisappear : MonoBehaviour
{
    public GameObject obj;
    public float activeTime;

    void Update()
    {
        if (obj.active == true)
        {
            StartCoroutine(Disableobj());
        }
    }
    IEnumerator Disableobj()
    {
        yield return new WaitForSeconds(activeTime);
        obj.SetActive(false);
    }
}