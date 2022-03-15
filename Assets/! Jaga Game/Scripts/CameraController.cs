using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 100f;

    public Transform player;

    float rotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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

    void FreezeTime()
    {
        cameraSpeed = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    void UnFreezeTime()
    {
        cameraSpeed = 500f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
