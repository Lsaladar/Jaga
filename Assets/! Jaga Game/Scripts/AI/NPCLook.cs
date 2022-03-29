using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLook : MonoBehaviour
{
    public bool contact;

    void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.tag == "NINPC")
        {
            transform.LookAt(other.gameObject.transform);
        }

        bool contact = true;

        Debug.Log(contact);
        
    }

}
