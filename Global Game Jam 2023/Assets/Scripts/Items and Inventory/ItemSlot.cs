using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IClickable
{
    public Item Item;
    private GameObject _xButton;

    private void Awake()
    {
        Item = null;
        _xButton = transform.GetChild(0).gameObject;
        _xButton.SetActive(false);
    }

    public void OnClick()
    { 
        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.Dialogue)
        {
            return;
        }
        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.PopUp)
        {
            return;
        }
        if(Item == null)
        {
            return;
        }    

        GameManager.Instance.SwitchGameState(GameManager.GameStates.UsingItem);
        gameObject.transform.localScale = 2 * InventoryManager.Instance.SpriteScale * Vector3.one;
        _xButton.SetActive(true);
        // TO DO: reveal X button
        // Let the inventory manager know that this item is in use
        InventoryManager.Instance.ItemInUse = this;
    }

    public void StopUsingItem()
    {
        _xButton.SetActive(false);
        gameObject.transform.localScale = InventoryManager.Instance.SpriteScale * Vector3.one;
        InventoryManager.Instance.ItemInUse = null;
        GameManager.Instance.SwitchGameState(GameManager.GameStates.FreePlay);
    }

    public void AddItem(Item item)
    {
        Debug.Log("Add item");
        Item = item;
        // Make item sprite visible
        Image image = gameObject.GetComponent<Image>();
        Color tempColor = image.color;
        tempColor.a = 1;
        image.color = tempColor;
        image.sprite = Item.Sprite;
    }

    public void RemoveItem()
    {
        Item = null;
        // Make slot transparent
        Image image = gameObject.GetComponent<Image>();
        Color tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
    }
}
