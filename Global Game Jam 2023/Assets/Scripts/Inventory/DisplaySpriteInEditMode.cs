using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DisplaySpriteInEditMode : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<ItemGameObject>().ItemData.Sprite;
    }
}
