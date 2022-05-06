using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AllInteractions : MonoBehaviour, IInteractable
{
    public Flowchart flowchart;

    [Header("Names")]
    public string characterName = "NPC";
    public string itemName = "Item";

    [Header("Item Variables")]
    public ItemInspect itemInspect;
    //public InspectZoom itemZoom;

    public Transform inspectionDistance;
    public Transform item;

    [Header("Door Variables")]
    public Door door;

    public string GetCharacterDescription()
    {
        return "Talk with " + characterName;
    }

    public string GetItemDescription()
    {
        return "Pick up " + itemName;
    }

    public void ChristianInteract()
    {
        flowchart.ExecuteBlock("First Interaction Christian");
    }

    public void PaganInteract()
    {
        flowchart.ExecuteBlock("First Interaction Pagan");
    }

    public void ItemInteract()
    {
        itemInspect.isInspecting = true;
        item.position = inspectionDistance.position;
    }

    public void ItemZoom()
    {
        //ItemZoom.inspecting = true;
    }

    public void OpenDoor()
    {
        door.open = true;
    }
}
