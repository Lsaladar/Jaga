using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AllInteractions))]
public class InspectZoom : MonoBehaviour
{
    public bool inspecting = false;
    public Transform player;
    public Transform target;

    public GameObject camHolder;

    public float zoomSpeed = 10f;

    public CameraController cam;

    public PlayerInteractions playerInteractions;

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
            MoveCam();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inspecting = false;
                playerInteractions.isInspecting = false;
                cam.UnFreezeTime();
                //inspectionUI.SetActive(false);
                ReturnCam();

            }
        }
    }

    public void MoveCam()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, zoomSpeed * Time.deltaTime);
    }

    public void ReturnCam()
    {
        Vector3 newPost = new Vector3(player.position.x, player.position.y, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPost, zoomSpeed * Time.deltaTime);
    }
}
