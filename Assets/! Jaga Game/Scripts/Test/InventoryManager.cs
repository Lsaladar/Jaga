using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    Item item;

    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    //public int slot = 1;
    //public Image[] iconImage;

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        ListItems();
    }

    //public void AddMediumItem(Item item)
    //{
    //    Items.Add(item);
    //    UpdateInventory();
    //}

    //public void AddLargeItem(Item item)
    //{
    //    Items.Add(item);
    //    UpdateInventory();
    //}

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        ListItems();
    }

    public void ListItems()
    {
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }
}
