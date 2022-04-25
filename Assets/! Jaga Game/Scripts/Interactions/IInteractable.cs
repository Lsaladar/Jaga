using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void ChristianInteract();
    void PaganInteract();
    void ItemInteract();
    void ItemZoom();
    string GetCharacterDescription();
    string GetItemDescription();
}
