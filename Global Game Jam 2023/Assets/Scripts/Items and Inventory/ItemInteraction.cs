using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInteraction : MonoBehaviour, IClickable
{
    public string TriggeringItemName;
    public UnityEvent ItemEvent;

    public void OnClick()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.UsingItem)
        {
            CheckForItemInteraction(InventoryManager.Instance.ItemInUse.Item);
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
            ItemEvent.Invoke();
        }
        else
        {
            // I guess do nothing? Maybe play a sound effect or do a lil animation?
        }
    }
}
