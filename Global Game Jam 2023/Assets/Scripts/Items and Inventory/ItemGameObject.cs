using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGameObject : MonoBehaviour, IClickable
{
    // TO DO
        // Pickup SFX and animation

    // Click the item to pick it up
    public Item Item;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = Item.Sprite;

        if(Item.PopUpSprite == null)
        {
            Item.PopUpSprite = Item.Sprite;
        }
    }

    public void OnClick()
    {
        InventoryManager.Instance.AddItem(Item);
        OnDestroy();
    }

    private void OnDestroy()
    {
        //Destroy this
            // Play sound effect
            // Lil animation
        Destroy(gameObject);
    }
}

