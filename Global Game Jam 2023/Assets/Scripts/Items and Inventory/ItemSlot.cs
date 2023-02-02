using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IClickable
{
    public Item Item;

    public void OnClick()
    { 
        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.Dialogue)
        {
            return;
        }
        if(Item == null)
        {
            return;
        }    

        GameManager.Instance.CurrentGameState = GameManager.GameStates.UsingItem;
        // TO DO: make item big

        Debug.Log("Item clicked!");
        // Let the inventory manager know that this item is in use
        InventoryManager.Instance.ItemInUse = this;
    }

    public void AddItem(Item item)
    {
        Item = item;
        // Make item sprite visible
        Image image = gameObject.GetComponent<Image>();
        Color tempColor = image.color;
        tempColor.a = 1;
        image.color = tempColor;
        image.sprite = Item.Sprite;
    }

    public void RemoveItem(Item item)
    {
        Item = null;
        // Make slot transparent
        Image image = gameObject.GetComponent<Image>();
        Color tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
        image.sprite = Item.Sprite;
    }
}
