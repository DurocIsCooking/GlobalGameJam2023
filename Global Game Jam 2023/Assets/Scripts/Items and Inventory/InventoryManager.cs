using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // TO DO
    // dotween animation when items are added, removed, or shifted in inventory 
    // In "HasItem" function, make sure it throws an error message for an item name that doesn't exist

    // Singleton pattern
    public static InventoryManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        GenerateItemSlots();
    }


    public ItemSlot ItemInUse;

    // List of items
    private List<ItemSlot> _itemSlots = new List<ItemSlot>();
    
    // Number of item slots
    [SerializeField] private int _numItemSlots;

    // UI
    [Header("UI")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private float _spriteScale = 1;
    [Header("UI Screen Positions")]
    [SerializeField] private Vector2 _firstItemPosition; // Position from the bottom left of the screen
    [SerializeField] private float _itemPositionInterval; // Distance between items, in % of screen width
    
    // Creates item slots with the specified positions and scale.
    private void GenerateItemSlots()
    {
        if(_canvas.GetComponent<Canvas>() == null)
        {
            Debug.Log("Error: no canvas found");
        }

        // For each item slot...
        for(int i = 0; i < _numItemSlots; i++)
        {
            // 1) CREATE ITEM SLOT AND ADD NECESSARY COMPONENTS

            // Create a game object, parent it to the canvas
            GameObject itemSlotGameObject = new GameObject();
            itemSlotGameObject.transform.SetParent(_canvas.transform);

            // Add image component, scale image, and make image transparent since the item slot is empty
            Image image = itemSlotGameObject.AddComponent<Image>();
            itemSlotGameObject.GetComponent<RectTransform>().localScale = new Vector3(_spriteScale, _spriteScale, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

            // Add ItemSlot script
            itemSlotGameObject.AddComponent<ItemSlot>();

            // Add button to detect clicks
            Button inventorySlotButton = itemSlotGameObject.AddComponent<Button>();
            inventorySlotButton.onClick.AddListener(itemSlotGameObject.GetComponent<ItemSlot>().OnClick); // Triggers ItemSlot's "OnClick" method when the button is clicked
            inventorySlotButton.transition = Selectable.Transition.None; // Makes it so button doesn't change colour when clicked
            

            // 2) PLACE ITEM SLOT IN UI

            // Anchor item slot to bottom left of canvas
            RectTransform rectTransform = itemSlotGameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.zero;

            // Calculate interval (distance between each item slot)
            float interval = _itemPositionInterval * i * _canvas.GetComponent<RectTransform>().rect.width / 100;

            // Set position
            Vector2 position = new Vector2(_firstItemPosition.x + interval, _firstItemPosition.y);
            rectTransform.position = position;


            // 3) ADD ITEM SLOT TO LIST

            _itemSlots.Add(itemSlotGameObject.GetComponent<ItemSlot>());

            // Add pair to dictionary
            //KeyValuePair<Vector2, Image> pair = new KeyValuePair<Vector2, Image>(position, image);
            //_itemSlots.Add(pair.Key, pair.Value);
            //_indexedPositions.Add(i, pair);
        }
    }

    public void AddItem(Item item)
    {
        foreach (ItemSlot itemSlot in _itemSlots)
        {
            if (itemSlot.Item != null)
            {
                continue;
            }

            itemSlot.AddItem(item);
            return;
        }
    }

    //private void RemoveItem(string itemName)
    //{
    //    foreach (Item item in Items)
    //    {
    //        if (item.name == itemName)
    //        {
    //            // remove item
    //            Items.Remove(item);
    //            RenderItemInUi();
    //        }
    //    }
    //}

    // Returns true if the inventory contains an item of the specified name
    public bool HasItem(string itemName)
    {
        foreach (ItemSlot itemSlot in _itemSlots)
        {
            if (itemSlot.Item.Name == itemName)
                return true;
        }
        return false;
    }

    // Returns the # of an item owned by the player
    public int ItemCount(string itemName)
    {
        int itemsFound = 0;
        foreach (ItemSlot itemSlot in _itemSlots)
        {
            if (itemSlot.Item.Name == itemName)
                itemsFound += 1;
        }
        return itemsFound;
    }

    //private void RenderItemInUi(ItemSlot itemSlot)
    //{
    //    itemSlot.gameObject.GetComponent<Image>().sprite = itemSlot.Item.Sprite;

    //    // Iterate through dictionary and set values
    //    for (int i = 0; i < _indexedPositions.Count; i++)
    //    {
    //        if (Items.Count > i)
    //        {
    //            // Add item
    //            Color tempColor = _indexedPositions[i].Value.color;
    //            tempColor.a = 1;
    //            _indexedPositions[i].Value.color = tempColor;
    //            _indexedPositions[i].Value.sprite = Items[i].Sprite;
    //        }
    //        else
    //        {
    //            // Make blank
    //            Color tempColor = _indexedPositions[i].Value.color;
    //            tempColor.a = 0;
    //            _indexedPositions[i].Value.color = tempColor;
    //            _indexedPositions[i].Value.sprite = null;
    //        }
    //    }
    //}

    // Draws cubes that show where items will display in UI
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        float itemCount = 0;

        for (int i = 0; i < _numItemSlots; i++)
        {
            Gizmos.matrix = _canvas.transform.localToWorldMatrix;
            float xOffset = _canvas.GetComponent<RectTransform>().rect.width / 2;
            float yOffset = _canvas.GetComponent<RectTransform>().rect.height / 2;
            float interval = _itemPositionInterval * itemCount * _canvas.GetComponent<RectTransform>().rect.width / 100;
            Vector2 position = new Vector2(_firstItemPosition.x + interval - xOffset, _firstItemPosition.y - yOffset);
            Gizmos.DrawCube(position, new Vector3(100, 100, 100) * _spriteScale);
            itemCount += 1;
        }
    }
}
