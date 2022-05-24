using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 10f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    public bool isInspecting = false;

    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one/2f);
        RaycastHit hit;

        bool hitSomething = false;

        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                hitSomething = true;

                if(hit.collider.name == "Bolek" || hit.collider.name == "Lolek" || hit.collider.name == "Priest" || hit.collider.name == "Chieftan" || hit.collider.name == "Brewess" || hit.collider.name == "Hunter")
                {
                    interactionText.text = interactable.GetCharacterDescription();
                }
                else if(hit.collider.tag == "Interactable Item")
                {
                    interactionText.text = interactable.GetItemDescription();
                }
                else if (hit.collider.tag == "Door")
                {
                    interactionText.text = "Open Door";
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.collider.name == "Bolek")
                    {
                        interactable.BolekInteract();
                    }
                    else if(hit.collider.name == "Lolek")
                    {
                        interactable.LolekInteract();
                    }
                    else if(hit.collider.name == "Priest")
                    {
                        interactable.PriestInteract();
                    }
                    else if(hit.collider.tag == "Interactable Item")
                    {
                        interactable.ItemInteract();
                        isInspecting = true;
                    }
                    else if(hit.collider.tag == "Zoom Item")
                    {
                        interactable.ItemZoom();   
                    }
                    else if (hit.collider.tag == "Door")
                    {
                        interactable.OpenDoor();
                    }

                }
            }
        }

        if (!isInspecting)
        {
            interactionUI.SetActive(hitSomething);
        }
    }
        
}
