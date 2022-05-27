using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public InventoryItemController[] inventoryItems;
    void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        ListItems();
    }

    public void RemoveItem(Item item)
    {
        Items.Add(item);
    }

    public void ListItems()
    {
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();

            itemIcon.sprite = item.icon;
        }

        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i < Items.Count; i++)
        {
            inventoryItems[i].AddItem(Items[i]);
        }
    }
}
