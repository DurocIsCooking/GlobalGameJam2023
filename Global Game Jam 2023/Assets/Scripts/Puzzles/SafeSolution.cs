using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSolution : MonoBehaviour
{
    public ItemGameObject BookArchaic;
    public ItemGameObject MusicSheet1;

    public void GiveSafeReward()
    {
        InventoryManager.Instance.AddItem(BookArchaic.Item);
        InventoryManager.Instance.AddItem(MusicSheet1.Item);
    }
}
