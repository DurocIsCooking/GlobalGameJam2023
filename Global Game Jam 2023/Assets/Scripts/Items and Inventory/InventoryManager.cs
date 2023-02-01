using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // TO DO
    // Make items scriptable objects
    // dotween animation when items are added, removed, or shifted in inventory 
    // In "HasItem" function, make sure it throws an error message for an item name that doesn't exist

    [HideInInspector] public List<ItemScriptableObject> Items = new List<ItemScriptableObject>();
    [SerializeField] private int _numItemSlots;

    // UI
    [Header("UI")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private float _spriteScale = 1;
    [Header("UI Screen Positions")]
    [SerializeField] private Vector2 _firstItemPosition; // Position from the bottom left of the screen
    [SerializeField] private float _itemPositionInterval; // Distance between items, in % of screen width
    // Dictionary of Ui positions and gameobjects with sprites (there is a gameobject at each UI position)
    private Dictionary<Vector2, Image> _uiScreenPositions = new Dictionary<Vector2, Image>();
    private Dictionary<int, KeyValuePair<Vector2, Image>> _indexedPositions = new Dictionary<int, KeyValuePair<Vector2, Image>>();

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

        SetUiScreenPositions();
    }

    private void SetUiScreenPositions()
    {
        if(_canvas.GetComponent<Canvas>() == null)
        {
            Debug.Log("Error: no canvas found");
        }

        for(int i = 0; i < _numItemSlots; i++)
        {
            // Create a game object with an image component at each position to place sprites
            GameObject uiAnchor = new GameObject();
            uiAnchor.transform.SetParent(_canvas.transform);
            Image image = uiAnchor.AddComponent<Image>();
            uiAnchor.GetComponent<RectTransform>().localScale = new Vector3(_spriteScale, _spriteScale, 1);
            // Make image transparent
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0); // Set image alpha to 0;

            // Anchor image to bottom left of canvas
            RectTransform rectTransform = uiAnchor.GetComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.zero;

            // Calculate interval
            float interval = _itemPositionInterval * i * _canvas.GetComponent<RectTransform>().rect.width / 100;

            // Set position
            Vector2 position = new Vector2(_firstItemPosition.x + interval, _firstItemPosition.y);
            rectTransform.position = position;

            // Add pair to dictionary
            KeyValuePair<Vector2, Image> pair = new KeyValuePair<Vector2, Image>(position, image);
            _uiScreenPositions.Add(pair.Key, pair.Value);
            _indexedPositions.Add(i, pair);
        }
    }

    public void AddItem(ItemScriptableObject item)
    {
        Items.Add(item);
        RenderItemsInUi();
    }

    private void RemoveItem(string itemName)
    {
        foreach (ItemScriptableObject item in Items)
        {
            if (item.name == itemName)
            {
                // remove item
                Items.Remove(item);
                RenderItemsInUi();
            }
        }
    }

    // Returns true if the inventory contains an item of the specified name
    public bool HasItem(string itemName)
    {
        foreach(ItemScriptableObject item in Items)
        {
            if (item.name == itemName)
                return true;
        }
        return false;
    }
    
    // Returns true if the player has N or more items of the specified name, where N = count
    public bool HasItem(string itemName, int count)
    {
        int itemsFound = 0;
        foreach (ItemScriptableObject item in Items)
        {
            if (item.name == itemName)
                itemsFound++;
        }
        if (itemsFound >= count)
            return true;

        return false;
    }

    private void RenderItemsInUi()
    {
        // Iterate through dictionary and set values
        for(int i = 0; i < _indexedPositions.Count; i++)
        {
            if (Items.Count > i)
            {
                // Add item
                Color tempColor = _indexedPositions[i].Value.color;
                tempColor.a = 1;
                _indexedPositions[i].Value.color = tempColor;
                _indexedPositions[i].Value.sprite = Items[i].Sprite;
            }
            else
            {
                // Make blank
                Color tempColor = _indexedPositions[i].Value.color;
                tempColor.a = 0;
                _indexedPositions[i].Value.color = tempColor;
                _indexedPositions[i].Value.sprite = null;
            }
        }
    }

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
