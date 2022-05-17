using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public DayCycleController dayCycle;

    public float cameraSpeed = 100f;

    public Transform player;

    float rotation = 0f;

    public GameObject interactionUI;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private HeadBobController headBobController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerController = GetComponentInParent<PlayerController>();
        headBobController = GetComponentInParent<HeadBobController>();
        dayCycle = GetComponent<DayCycleController>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime;

        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }

    public void FreezeTime()
    {
        cameraSpeed = 0f;
        Cursor.lockState = CursorLockMode.None;
        playerController.canMove = false;
        headBobController._enable = false;
        interactionUI.SetActive(false);
        dayCycle.isEnabled = false;
    }

    public void UnFreezeTime()
    {
        cameraSpeed = 500f;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.canMove = true;
        headBobController._enable = true;
        interactionUI.SetActive(true);
        dayCycle.isEnabled = true;
    }
}
