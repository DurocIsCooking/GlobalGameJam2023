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

        // Pop-up window
        PopUpWindow.gameObject.SetActive(false);
        PopUpWindow.color = Color.white;
        PopUpWindow.transform.GetChild(0).gameObject.SetActive(false); // Child object is a TextMeshPro that says "Pop-up window" for UI design purposes.
        _popUpButton = PopUpWindow.transform.GetChild(1).gameObject;
    }

    // Pop-up window
    public Image PopUpWindow;
    private GameObject _popUpButton;

    // Item management
    public GameObject ItemSlotPrefab;
    [HideInInspector] public ItemSlot ItemInUse;
    private List<ItemSlot> _itemSlots = new List<ItemSlot>();
    [SerializeField] private int _numItemSlots;

    // UI
    [Header("UI")]
    [SerializeField] private GameObject _canvas;
    public float SpriteScale = 1;
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
            GameObject itemSlotGameObject = Instantiate(ItemSlotPrefab);
            itemSlotGameObject.transform.SetParent(_canvas.transform);

            // Scale item slot
            itemSlotGameObject.GetComponent<RectTransform>().localScale = new Vector3(SpriteScale, SpriteScale, 1);

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
        }
    }

    public void AddItem(Item item)
    {
        Debug.Log("Adding item");
        foreach (ItemSlot itemSlot in _itemSlots)
        {
            if (itemSlot.Item != null)
            {
                Debug.Log("Slot full");
                continue;
            }
            Debug.Log("Found empty slot");
            itemSlot.AddItem(item);
            return;
        }
    }

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

    public void OpenPopUp(Item item)
    {
        PopUpWindow.gameObject.SetActive(true);
        PopUpWindow.sprite = item.PopUpSprite;
        if(ItemInUse.Item.PopUpEvent.GetPersistentEventCount() == 0)
        {
            _popUpButton.SetActive(false);
        }
        else
        {
            _popUpButton.SetActive(true);
        }

        GameManager.Instance.SwitchGameState(GameManager.GameStates.PopUp);
    }

    public void ClosePopUp()
    {
        PopUpWindow.gameObject.SetActive(false);
    }

    public void UsePopUpItem()
    {
        ItemInUse.Item.PopUpEvent.Invoke();
        ItemInUse.StopUsingItem();
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
            Gizmos.DrawCube(position, new Vector3(100, 100, 100) * SpriteScale);
            itemCount += 1;
        }
    }
}
