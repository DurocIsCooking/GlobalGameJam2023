using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickEvent : MonoBehaviour, IClickable
{
    public enum EventTypes
    {
        Default,
        Puzzle,
        Dialogue
    }
    public EventTypes EventType;

    public string TriggeringItemName;
    public bool DestroyItemOnClick;
    public UnityEvent EventToTrigger;

    public void OnClick()
    {

        if(gameObject.GetComponent<ItemGameObject>() != null)
        {
            return;
        }

        if (GameManager.Instance.CurrentGameState == GameManager.GameStates.UsingItem)
        {
            Debug.Log("Try item interaction");
            CheckForItemInteraction(InventoryManager.Instance.ItemInUse.Item);
            return;
        }

        switch (EventType)
        {
            case EventTypes.Puzzle: // Safe, old box, piano
                EventToTrigger.Invoke();
                GameManager.Instance.SwitchGameState(GameManager.GameStates.Puzzle);
                break;
            case EventTypes.Dialogue:
                if (GameManager.Instance.CurrentGameState == GameManager.GameStates.FreePlay)
                {
                    EventToTrigger.Invoke();
                }
                break;
        }

        
    }

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
            if (DestroyItemOnClick)
            {
                InventoryManager.Instance.ItemInUse.RemoveItem();
            }
            EventToTrigger.Invoke();
            
        }
        else
        {
            DialogueManager.Instance.WrongItemDialogue();
        }
    }

}
