using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchchec : MonoBehaviour
{
    public GameObject torchchek;
    public GameObject torchOn;
    public GameObject torchOff;

    // Update is called once per frame
    void Update()
    {
        if (torchchek.activeInHierarchy)
        {
            torchOn.SetActive(true);
            torchOff.SetActive(false);
        }
        else
        {
            torchOff.SetActive(true);
            torchOn.SetActive(false);
        }
    }
}
