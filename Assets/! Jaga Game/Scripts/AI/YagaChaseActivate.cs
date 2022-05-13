using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YagaChaseActivate : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        YAI2.isStalking = true;

        //Debug.Log("p");
        
    }
}
