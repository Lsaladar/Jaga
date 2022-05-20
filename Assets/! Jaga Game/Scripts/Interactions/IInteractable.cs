using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void BolekInteract();
    void LolekInteract();
    void ItemInteract();
    void PriestInteract();
    void ChieftanInteract();
    void ItemZoom();
    void OpenDoor();
    string GetCharacterDescription();
    string GetItemDescription();
}
