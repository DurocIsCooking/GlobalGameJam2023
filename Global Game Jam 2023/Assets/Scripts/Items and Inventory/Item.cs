using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Item
{
    public string Name;
    public Sprite Sprite;
    public Sprite PopUpSprite;
    public bool PopUpFromInventory;
    public UnityEvent PopUpEvent;
    public string PuzzleName;
}
