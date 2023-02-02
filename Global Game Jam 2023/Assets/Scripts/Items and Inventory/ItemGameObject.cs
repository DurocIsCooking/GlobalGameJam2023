using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGameObject : MonoBehaviour, IClickable
{
    // TO DO
        // Pickup SFX and animation

    // Click the item to pick it up
    private PolygonCollider2D _collider;
    public ItemScriptableObject ItemData;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = ItemData.Sprite;
    }

    public void OnClick()
    {
        InventoryManager.Instance.AddItem(ItemData);
        OnDestroy();
    }

    private void OnDestroy()
    {
        //Destroy this
            // Play sound effect
            // Lil animation
        Destroy(gameObject);
    }
}

