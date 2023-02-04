using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor.Events;

public class ConnectButtonToAudioManager : MonoBehaviour
{
    public string ClickSfxString;
    public string HoverSfxString;

    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(delegate { ConnectToManager(ClickSfxString); });

        EventTrigger buttonHoverTrigger = gameObject.GetComponent<EventTrigger>();

        if(buttonHoverTrigger != null)
        {
            var onPointerEnter = new EventTrigger.Entry();
            onPointerEnter.eventID = EventTriggerType.PointerEnter;
            UnityEventTools.AddPersistentListener(onPointerEnter.callback, delegate { ConnectToManager(HoverSfxString); });

            buttonHoverTrigger.triggers.Add(onPointerEnter);
        }
    }

    void ConnectToManager(string sfx)
    {
        AudioManager.Instance.PlaySFX(sfx);
    }
}