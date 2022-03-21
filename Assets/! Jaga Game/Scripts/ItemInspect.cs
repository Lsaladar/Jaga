using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspect : MonoBehaviour
{
    public Transform item;

    public bool isInspecting = false;

    public Transform inpsectionDistance;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInspecting)
        {
            item = inpsectionDistance;
        }
    }
}
