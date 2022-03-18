using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;


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
                interactionText.text = interactable.GetDescription();

                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.collider.tag == "Christian_NPC")
                    {
                        interactable.ChristianInteract();
                    }
                    else if(hit.collider.tag == "Pagan_NPC")
                    {
                        interactable.PaganInteract();
                    }
                    //interactable.Interact();
                }
            }
        }

        interactionUI.SetActive(hitSomething);
    }
}
