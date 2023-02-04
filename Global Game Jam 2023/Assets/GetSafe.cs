using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSafe : MonoBehaviour
{
    public void GetSafeEvent()
    {
        Item safe = transform.GetComponentInChildren<ItemGameObject>().Item;
        InventoryManager.Instance.AddItem(safe);
    }
}
