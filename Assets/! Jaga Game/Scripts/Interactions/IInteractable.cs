using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void ChristianInteract();
    void PaganInteract();
    void ItemInteract();
    void ItemZoom();
    void OpenDoor();
    string GetCharacterDescription();
    string GetItemDescription();
}
