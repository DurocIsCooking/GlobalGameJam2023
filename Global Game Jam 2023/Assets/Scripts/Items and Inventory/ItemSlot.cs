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
        // if inventory slot is empty, return
        if (Item == null)
        {
            return;
        }

        // Can't interact with items while in dialogue mode or puzzle mode
        if (GameManager.Instance.CurrentGameState == GameManager.GameStates.Dialogue || GameManager.Instance.CurrentGameState == GameManager.GameStates.Puzzle)
        {
            return;
        }

        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.Cutscene)
        {
            return;
        }    

        // If the player switches items, they stop using their current item
        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.PopUp) // This could get buggy with minigames
        {
            InventoryManager.Instance.ItemInUse.StopUsingItem();
        }
        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.UsingItem)
        {
            InventoryManager.Instance.ItemInUse.StopUsingItem();
        }

        // Let the inventory manager know that this item is in use
        InventoryManager.Instance.ItemInUse = this;

        // Switch game state
        GameManager.Instance.SwitchGameState(GameManager.GameStates.UsingItem);


        if(Item.PuzzleName != "")
        {
            Debug.Log("it has a puzzle");
            PuzzleManager.Instance.PuzzleUp(Item.PuzzleName);
        }

        // Handle pop-up if applicable
        if (Item.PopUpFromInventory)
        {
            InventoryManager.Instance.OpenPopUp(Item);
        }

        // UI changes, to show that item is in use and to give the player a way to cancel action
        gameObject.transform.localScale = 2 * InventoryManager.Instance.SpriteScale * Vector3.one;
        _xButton.SetActive(true);
    }

    public void StopUsingItem()
    {
        _xButton.SetActive(false);
        gameObject.transform.localScale = InventoryManager.Instance.SpriteScale * Vector3.one;

        if (Item.PuzzleName != "")
        {
            PuzzleManager.Instance.PuzzleDown("Regular");
        }
        InventoryManager.Instance.ItemInUse = null;
        //if(GameManager.Instance.CurrentGameState == GameManager.GameStates.UsingItem)
        GameManager.Instance.SwitchGameState(GameManager.GameStates.FreePlay);
        InventoryManager.Instance.ClosePopUp();
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
        StopUsingItem();
        Item = null;
        // Make slot transparent
        Image image = gameObject.GetComponent<Image>();
        Color tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
    }
}
