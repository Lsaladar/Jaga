using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLook : MonoBehaviour
{

    void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.tag == "NINPC")
        {
            transform.LookAt(other.gameObject.transform);
        }
    }
}
