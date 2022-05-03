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

        //if(item.value == 1)
        //{
        //    InventoryManager.Instance.AddSmallItem(item);
        //    Destroy(gameObject);
        //}
        //else if(item.value == 2)
        //{
        //    InventoryManager.Instance.AddMediumItem(item);
        //    Destroy(gameObject);
        //}
        //else if(item.value == 3)
        //{
        //    InventoryManager.Instance.AddLargeItem(item);
        //    Destroy(gameObject);
        //}
    }
}
