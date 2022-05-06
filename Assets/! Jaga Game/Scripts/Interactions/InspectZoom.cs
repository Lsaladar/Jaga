using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AllInteractions))]
public class InspectZoom : MonoBehaviour
{
    public bool inspecting = false;
    public Transform ogPos;
    public Transform newPos;

    public GameObject camHolder;

    public float zoomSpeed = 10f;

    public CameraController cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(inspecting)
        // {
        //     cam.FreezeTime();
        //     camHolder.transform.position = Vector3.Lerp(ogPos, newPos, zoomSpeed * Time.deltaTime);
        // }
        // else
        // {
        //     cam.UnFreezeTime();
        //     camHolder.transform.position = Vector3.Lerp(newPos, ogPos, zoomSpeed * Time.deltaTime);
        // }
    }
}
