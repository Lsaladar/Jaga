using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AllInteractions))]
public class ItemInspect : MonoBehaviour
{
    public bool isInspecting = false;

    public Transform item;

    public Transform originalPos;

    public CameraController cam;

    private Vector3 lastPos, currPos;
    public float rotationSpeed = -0.2f;

    ItemPickUp itemPickUp;
    

    // Start is called before the first frame update
    void Start()
    {
        lastPos = Input.mousePosition;

        itemPickUp = GetComponent<ItemPickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInspecting)
        {
            cam.FreezeTime();

            if (Input.GetMouseButton(0))
            {
                currPos = Input.mousePosition;
                Vector3 offset = currPos - lastPos;
                transform.RotateAround(transform.position, Vector3.up, offset.x * rotationSpeed * Time.deltaTime);
            }
            lastPos = Input.mousePosition;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isInspecting = false;
                cam.UnFreezeTime();
                item.position = originalPos.position;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                itemPickUp.PickUpItem();
                isInspecting = false;
                cam.UnFreezeTime();
                item.position = originalPos.position;
            }
        }
    }
}
