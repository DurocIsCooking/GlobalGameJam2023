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
        if(GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().sprite = Item.Sprite;
        }
        
        if(Item.PopUpSprite == null)
        {
            Item.PopUpSprite = Item.Sprite;
        }
    }

    public void OnClick()
    {
        if(GameManager.Instance.CurrentGameState != GameManager.GameStates.FreePlay)
        {
            return;
        }
        AudioManager.Instance.PlaySFX("Pickup");
        InventoryManager.Instance.AddItem(Item);
        OnDestroy();
    }

    private void OnDestroy()
    {
        if(gameObject.GetComponent<OnClickEvent>() != null)
        {
            gameObject.GetComponent<OnClickEvent>().EventToTrigger.Invoke();
        }
        // Play sound effect
        // Lil animation
        Destroy(gameObject);
    }
}

