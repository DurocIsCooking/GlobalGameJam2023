using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickEvent : MonoBehaviour, IClickable
{
    public enum EventTypes
    {
        ItemInteraction,
        PopUp,
        Dialogue
    }
    public EventTypes EventType;

    public string TriggeringItemName;
    public bool DestroyItemOnClick;
    public UnityEvent EventToTrigger;

    public void OnClick()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameStates.UsingItem)
        {
            CheckForItemInteraction(InventoryManager.Instance.ItemInUse.Item);
        }

        switch (EventType)
        {
            case EventTypes.ItemInteraction:
                if (GameManager.Instance.CurrentGameState == GameManager.GameStates.UsingItem)
                {
                    CheckForItemInteraction(InventoryManager.Instance.ItemInUse.Item);
                }
                else
                {
                    // Some kind of default interaction I guess? Play default dialogue / SFX?
                }
                break;
            case EventTypes.PopUp: // Safe, old box, piano
                GameManager.Instance.SwitchGameState(GameManager.GameStates.PopUp);
                break;
            case EventTypes.Dialogue:
                if (GameManager.Instance.CurrentGameState == GameManager.GameStates.FreePlay)
                {
                    GameManager.Instance.SwitchGameState(GameManager.GameStates.Dialogue);
                    EventToTrigger.Invoke();
                }
                break;
        }

        
    }
    //tenst
    public void CheckForItemInteraction(Item item)
    {
        if(item == null)
        {
            Debug.Log("Error: attempting to use an empty item slot!");
            return;
        }

        if(item.Name == TriggeringItemName)
        {
            // Trigger an event
            EventToTrigger.Invoke();
            if(DestroyItemOnClick)
            {
                InventoryManager.Instance.ItemInUse.RemoveItem();
            }
        }
        else
        {
            // I guess do nothing? Maybe play a sound effect or do a lil animation?
            // Maybe trigger dialogue that says "I don't think that works"?
        }
    }

}