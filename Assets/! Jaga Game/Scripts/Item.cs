using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        SmallCube,
        LargeCube,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.SmallCube:    return ItemAssets.Instance.smallCubeSprite;
            case ItemType.LargeCube:    return ItemAssets.Instance.largeCubeSprite;
        }
    }
}
