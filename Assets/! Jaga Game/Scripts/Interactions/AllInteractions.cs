using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AllInteractions : MonoBehaviour, IInteractable
{
    [Header("Fungus Variables")]
    public Flowchart flowchart;
    public string blockName;

    [Header("Names")]
    public string characterName = "NPC";
    public string itemName = "Item";

    [Header("Item Variables")]
    public ItemInspect itemInspect;
    public InspectZoom itemZoom;

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

    public void BolekInteract()
    {
        flowchart.ExecuteBlock(blockName);
    }

    public void LolekInteract()
    {
        flowchart.ExecuteBlock(blockName);
    }

    public void PriestInteract()
    {
        flowchart.ExecuteBlock(blockName);
    }

    public void ChieftanInteract()
    {
        flowchart.ExecuteBlock(blockName);
    }

    void BrewessInteract()
    {
        flowchart.ExecuteBlock(blockName);
    }

    void HunterInteract()
    {
        flowchart.ExecuteBlock(blockName);
    }

    public void ItemInteract()
    {
        itemInspect.isInspecting = true;
        item.position = inspectionDistance.position;
    }

    public void ItemZoom()
    {
        itemZoom.inspecting = true;
    }

    public void OpenDoor()
    {
        door.open = true;
    }
}
