using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    public void PickUpItem()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }
}
