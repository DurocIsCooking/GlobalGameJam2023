using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConnectButtonToAudioManager : MonoBehaviour
{
    public string ClickSfxString;
    public string HoverSfxString;
    public bool Piano;

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
            onPointerEnter.callback.AddListener(delegate { ConnectToManager(HoverSfxString); });
            buttonHoverTrigger.triggers.Add(onPointerEnter);
        }
    }

    void ConnectToManager(string sfx)
    {
        if(Piano)
        {
            AudioManager.Instance.PlayKey(int.Parse(sfx));
            return;
        }
        AudioManager.Instance.PlaySFX(sfx);
    }
}