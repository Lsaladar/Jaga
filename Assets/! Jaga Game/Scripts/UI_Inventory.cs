using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    Inventory inventory;
    Transform itemSlotContainer;
    Transform itemSlotTemplate;

    void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTrnasform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTrnasform.gameObject.SetActive(true);

            itemSlotRectTrnasform.anchoredPosition = new Vector3(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTrnasform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
