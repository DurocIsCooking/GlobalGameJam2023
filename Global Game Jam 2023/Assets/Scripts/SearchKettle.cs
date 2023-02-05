using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchKettle : MonoBehaviour
{
    public void SearchKettleEvent()
    {
        Item seed = transform.GetChild(0).GetComponent<ItemGameObject>().Item;
        Item musicScore = transform.GetChild(1).GetComponent<ItemGameObject>().Item;
        InventoryManager.Instance.AddItem(seed);
        InventoryManager.Instance.AddItem(musicScore);
        gameObject.SetActive(false);
    }
}
