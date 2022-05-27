using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item _item;

    public void PickUpItem()
    {
        InventoryManager.Instance.AddItem(_item);
        Destroy(gameObject);
    }
}
