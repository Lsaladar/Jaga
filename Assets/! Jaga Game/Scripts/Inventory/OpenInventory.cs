using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;
    bool isInventoryActive = false;

    void Update()
    {
        if(!isInventoryActive)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.SetActive(true);
                isInventoryActive = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.SetActive(false);
                isInventoryActive = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
            }
        }
    }
}
