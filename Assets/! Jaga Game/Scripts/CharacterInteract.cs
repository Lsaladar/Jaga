using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CharacterInteract : MonoBehaviour, IInteractable
{
    public Flowchart flowchart;

    public string characterName = "NPC";

    public string GetDescription()
    {
        return "Talk with " + characterName;
    }

    public void Interact()
    {
        flowchart.ExecuteBlock("First Interaction");
    }
}
