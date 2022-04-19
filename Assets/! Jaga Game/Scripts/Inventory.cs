using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.SmallCube, amount = 1 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
