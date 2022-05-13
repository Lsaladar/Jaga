using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLook : MonoBehaviour
{
    public bool contact = false;

    private NPCNavMesh npcNavMesh;

    void Start()
    {
        npcNavMesh = gameObject.GetComponent<NPCNavMesh>();

        //contact = npcNavMesh.hasContact;
    }
    private void Update() 
    {
        if (contact)
        {
            Debug.Log("c");
        }
    }

    void OnTriggerEnter (Collider other) 
    {
        
        transform.LookAt(other.gameObject.transform);
        

        bool contact = true;

        //Debug.Log(contact);
        
    }

    

}
