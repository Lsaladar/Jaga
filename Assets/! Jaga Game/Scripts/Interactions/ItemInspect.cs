using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

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
    public GameObject inspectionUI;

    public Volume volume;
    private DepthOfField blur;

    public PlayerInteractions playerInteractions;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerInteractions playerInteractions = GetComponent<PlayerInteractions>();

        volume.profile.TryGet(out blur);
        lastPos = Input.mousePosition;

        itemPickUp = GetComponent<ItemPickUp>();
        inspectionUI.SetActive(false);
        blur.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInspecting)
        {
            cam.FreezeTime();
            inspectionUI.SetActive(true);
            playerInteractions.isInspecting = true;
            blur.active = true;

            if (Input.GetMouseButton(0))
            {
                currPos = Input.mousePosition;
                Vector3 offset = currPos - lastPos;
                transform.RotateAround(transform.position, Vector3.up, offset.x * rotationSpeed * Time.deltaTime);
                transform.RotateAround(transform.position, Vector3.forward, offset.y * -rotationSpeed * Time.deltaTime);
            }
            lastPos = Input.mousePosition;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                blur.active = false;
                isInspecting = false;
                playerInteractions.isInspecting = false;
                cam.UnFreezeTime();
                inspectionUI.SetActive(false);
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
