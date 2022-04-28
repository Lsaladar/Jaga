//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Rendering;

//public class ItemWorld : MonoBehaviour
//{
//    Item item;
//    SpriteRenderer spriteRenderer;

//    //Light light;

//    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
//    {
//        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

//        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
//        itemWorld.SetItem(item);

//        return itemWorld;
//    }

//    void Awake()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();

//        //light = GetComponent<light>();
//    }

//    void SetItem(Item item)
//    {
//        this.item = item;
//        spriteRenderer.sprite = item.GetSprite();

//        //light.color = item.GetColor();
//    }

//    public Item GetItem()
//    {
//        return item;
//    }

//    public void DestorySelf()
//    {
//        Destroy(gameObject);
//    }
//}
