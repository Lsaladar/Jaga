using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    Item item;

    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    //public Transform itemContent;
    //public GameObject inventoryItem;

    public int slot = 1;
    public Image[] iconImage;

    void Awake()
    {
        Instance = this;
    }

    public void AddSmallItem(Item item)
    {
        Items.Add(item);
        UpdateInventory();
    }

    public void AddMediumItem(Item item)
    {
        Items.Add(item);
        UpdateInventory();
    }

    public void AddLargeItem(Item item)
    {
        Items.Add(item);
        UpdateInventory();
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        //switch (slot)
        //{
        //    case 1:
        //        Debug.Log("Item added to slot 1");
        //        iconImage[0].sprite = item.icon;
        //        slot++;s
        //        break;
        //}

        ////foreach(var item in Items)
        ////{
        ////    //GameObject obj = Instantiate(inventoryItem, itemContent);
        ////    //var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
        ////    //var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

        ////    //itemName.text = item.itemName;
        ////    //itemIcon.sprite = item.icon;
        ////}
    }
}
