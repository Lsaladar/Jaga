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

    public GameObject inspectionUI;

    public Volume volume;
    private DepthOfField blur;
    

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out blur);
        lastPos = Input.mousePosition;
        inspectionUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInspecting)
        {
            cam.FreezeTime();
            inspectionUI.SetActive(true);
            blur.FocusMode = true;

            if (Input.GetMouseButton(0))
            {
                currPos = Input.mousePosition;
                Vector3 offset = currPos - lastPos;
                transform.RotateAround(transform.position, Vector3.up, offset.x * rotationSpeed * Time.deltaTime);
            }
            lastPos = Input.mousePosition;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                blur.FocusMode = false;
                isInspecting = false;
                cam.UnFreezeTime();
                inspectionUI.SetActive(false);
                item.position = originalPos.position;
            }
        }
    }
}
