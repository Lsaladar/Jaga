using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspect : MonoBehaviour
{
    public Transform item;

    public bool isInspecting = false;

    public Transform originalPos;

    public CameraController cam;

    private Vector3 lastPos, currPos;
    public float rotationSpeed = -0.2f;
    

    // Start is called before the first frame update
    void Start()
    {
        lastPos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInspecting)
        {
            cam.FreezeTime();

            if (Input.GetMouseButtonDown(0))
            {
                currPos = Input.mousePosition;
                Vector3 offset = currPos - lastPos;
                transform.RotateAround(transform.position, Vector3.up, offset.x * rotationSpeed);
            }
            lastPos = Input.mousePosition;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isInspecting = false;
                cam.UnFreezeTime();
                item.position = originalPos.position;
            }
        }
    }
}
