using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void ChristianInteract();
    void PaganInteract();
    void ItemInteract();
    string GetCharacterDescription();
    string GetItemDescription();
}
