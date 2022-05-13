using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AllInteractions))]
public class InspectZoom : MonoBehaviour
{
    public bool inspecting = false;

    public GameObject camHolder;

    public CameraController cam;

    public PlayerInteractions playerInteractions;

    public GameObject inspectionUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inspecting)
        {
            playerInteractions.isInspecting = true;
            cam.FreezeTime();
            inspectionUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inspecting = false;
                playerInteractions.isInspecting = false;
                cam.UnFreezeTime();
                inspectionUI.SetActive(false);
            }
        }
    }
}
